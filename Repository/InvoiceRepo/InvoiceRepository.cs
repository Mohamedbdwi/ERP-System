using Microsoft.EntityFrameworkCore;
using Small_ERP.Migrations;
using Small_ERP.Models;
using Small_ERP.Repository.CustomerRepo;
using Small_ERP.Repository.StoreRepo;
using Small_ERP.ViewModels;
using System.Drawing.Drawing2D;

namespace Small_ERP.Repository.InvoiceRepo
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ERPDbContext _context;
        private readonly IStoreRepository StoreRepo;
        private readonly ICustomerRepository CustomerRepo;

        public InvoiceRepository(ERPDbContext db, IStoreRepository StoreRepo, ICustomerRepository CustomerRepo)
        {
            _context = db;
            this.StoreRepo = StoreRepo;
            this.CustomerRepo = CustomerRepo;
        }

        public async Task<List<InvoiceHeader>> GetAllInvoices()
        {
            return await _context.InvoiceHeaders.ToListAsync();
        }

        public Item GetPrice(int id)
        {
            Item itm = _context.Items.FirstOrDefault(x => x.Id == id);
            return itm;
        }

        public int GetInvoiceNumber()
        {
            var invoice = _context.InvoiceHeaders.OrderBy(i => i.Date).LastOrDefault();
            int invoiceNumber = int.Parse(invoice.Number);
            return invoiceNumber;
        }

        public async Task CreatingInvoice(InvoiceViewModel invoiceModel)
        {

            InvoiceHeader invoiceHeader = new InvoiceHeader();

            invoiceHeader.Number = invoiceModel.Number;
            invoiceHeader.Date = invoiceModel.Date;
            invoiceHeader.Customer_Id = invoiceModel.Customer_Id;
            invoiceHeader.Total_Cost = invoiceModel.Total_Cost;
            invoiceHeader.Paid = invoiceModel.Paid;
            invoiceHeader.Remainder = invoiceModel.Remainder;

            await _context.InvoiceHeaders.AddAsync(invoiceHeader);
            await _context.SaveChangesAsync();

            List<InvoiceDetails> items = invoiceModel.InvoiceDetails;

            foreach (var item in items)
            {
               
                Store storeItem = await _context.Stores.FirstOrDefaultAsync(s => s.Item_Id == item.Item_Id);
                if(item.Quantity <= storeItem.Quantity)
                {
                    item.InvoiceHeader_Id = invoiceHeader.Id;

                    await _context.InvoiceDetails.AddAsync(item);
                    await _context.SaveChangesAsync();

                    storeItem.Quantity -= item.Quantity;
                    await _context.SaveChangesAsync();
                }
                ItemMovement itemMovement = new ItemMovement();
                itemMovement.Movement_Type = "Selling";
                itemMovement.Quantity = item.Quantity;
                itemMovement.Bill_Number = invoiceModel.Number;
                itemMovement.Date = invoiceModel.Date;
                itemMovement.Item_Id = item.Item_Id;
                await _context.ItemMovements.AddAsync(itemMovement);
                await _context.SaveChangesAsync();

            }

            CustomerAccountStatement customerStatement = new CustomerAccountStatement();
            customerStatement.Customer_Id = invoiceModel.Customer_Id;
            customerStatement.Date = invoiceModel.Date;
            customerStatement.Total_Cost = invoiceModel.Total_Cost;
            customerStatement.Paid = invoiceModel.Paid;
            customerStatement.Remainder = invoiceModel.Remainder;
            await _context.CustomerAccountStatements.AddAsync(customerStatement);
            await _context.SaveChangesAsync();

            Customer customer = await CustomerRepo.GetCustomerById(invoiceModel.Customer_Id);

            DailyRestrictions dailyRestrictionDebtor = new DailyRestrictions();
            dailyRestrictionDebtor.Date = invoiceModel.Date;
            dailyRestrictionDebtor.Number = invoiceModel.Number;
            dailyRestrictionDebtor.Money_Amount = invoiceModel.Total_Cost;
            dailyRestrictionDebtor.Type = "Debtor";
            dailyRestrictionDebtor.Account = "Company";
            dailyRestrictionDebtor.AccountTree_Id = customer.AccountTree_Id;
            await _context.DailyRestrictions.AddAsync(dailyRestrictionDebtor);
            await _context.SaveChangesAsync();

            DailyRestrictions dailyRestrictionCreditor = new DailyRestrictions();
            dailyRestrictionCreditor.Date = invoiceModel.Date;
            dailyRestrictionCreditor.Number = invoiceModel.Number;
            dailyRestrictionCreditor.Money_Amount = invoiceModel.Paid;
            dailyRestrictionCreditor.Type = "Creditor";
            dailyRestrictionCreditor.Account = "Safes";
            dailyRestrictionCreditor.AccountTree_Id = customer.AccountTree_Id;
            await _context.DailyRestrictions.AddAsync(dailyRestrictionCreditor);
            await _context.SaveChangesAsync();

            Safes customerSafe = new Safes();
            customerSafe.Date = invoiceModel.Date;
            customerSafe.Money_Amount= invoiceModel.Paid;
            customerSafe.AccountTree_Id = customer.AccountTree_Id;
            await _context.Safes.AddAsync(customerSafe);
            await _context.SaveChangesAsync();

        }
    }
}
