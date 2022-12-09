using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;
using Small_ERP.ViewModels;

namespace Small_ERP.Repository.PurchaseBillRepo
{
    public class PurchaseBillRepository : IPurchaseBillRepository
    {
        private readonly ERPDbContext _context;

        public PurchaseBillRepository(ERPDbContext db)
        {
            _context = db;
        }

        public int GetBillNumber()
        {
            var invoice = _context.PurchasesBillHeaders.OrderBy(i => i.Date).LastOrDefault();
            int invoiceNumber = int.Parse(invoice.Number);
            return invoiceNumber;
        }
        //TODO:update the current record in the store
        public async Task CreatingBill(PurchaseBillViewModel billModel)
        {
            PurchasesBillHeader billHeader = new PurchasesBillHeader();

            billHeader.Number = billModel.Number;
            billHeader.Date = billModel.Date;
            billHeader.Supplier_Id = billModel.Supplier_Id;
            billHeader.Total_Cost = billModel.Total_Cost;
            billHeader.Paid = billModel.Paid;
            billHeader.Remainder = billModel.Remainder;

            await _context.PurchasesBillHeaders.AddAsync(billHeader);
            await _context.SaveChangesAsync();

            List<PurchasesBillDetails> items = billModel.PurchasesBillDetails;

            foreach (var item in items)
            {
                item.PurchasesBillHeader_Id = billHeader.Id;


                await _context.PurchasesBillDetails.AddAsync(item);
                await _context.SaveChangesAsync();

                Store storeItem = await _context.Stores.FirstOrDefaultAsync(s => s.Item_Id == item.Item_Id);
                storeItem.Quantity += item.Quantity;
                await _context.SaveChangesAsync();

                ItemMovement itemMovement = new ItemMovement();
                itemMovement.Movement_Type = "Purchase";
                itemMovement.Quantity = item.Quantity;
                itemMovement.Bill_Number = billModel.Number;
                itemMovement.Date = billModel.Date;
                itemMovement.Item_Id = item.Item_Id;
                await _context.ItemMovements.AddAsync(itemMovement);
                await _context.SaveChangesAsync();
            }

            SupplierAccountStatement supplierStatement = new SupplierAccountStatement();
            supplierStatement.Supplier_Id = billModel.Supplier_Id;
            supplierStatement.Date = billModel.Date;
            supplierStatement.Total_Cost = billModel.Total_Cost;
            supplierStatement.Paid = billModel.Paid;
            supplierStatement.Remainder = billModel.Remainder;
            await _context.SupplierAccountStatements.AddAsync(supplierStatement);
            await _context.SaveChangesAsync();


        }


    }
}
