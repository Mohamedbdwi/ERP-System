using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;

namespace Small_ERP.Repository.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ERPDbContext _context;

        public CustomerRepository(ERPDbContext db)
        {
            _context = db;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> allCustomers = await _context.Customers.ToListAsync();
            return allCustomers;
        }

        public int AccNumber()
        {
            var accNumber = _context.AccountTree.OrderBy(i => i.Id).LastOrDefault();
            int Number = int.Parse(accNumber.Acc_Id);
            return Number;
        }

        public async Task Insert(Customer newCustomer)
        {
            AccountTree accountTree = new AccountTree();
            var accNumber = AccNumber();
            accountTree.Acc_Id = (1+ accNumber).ToString();
            accountTree.Acc_Name = newCustomer.Name;
            await _context.AccountTree.AddAsync(accountTree);
            await _context.SaveChangesAsync();

            newCustomer.AccountTree_Id = accountTree.Id;
            await _context.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            Customer customer = await _context.Customers.Include(i=>i.AccountTree).FirstOrDefaultAsync(i => i.Id == Id);
            return customer;
        }

        public async Task<List<CustomerAccountStatement>> GetAccountStatementById(int id)
        {
            List<CustomerAccountStatement> accountStatements = await _context.CustomerAccountStatements.Where(s => s.Customer_Id == id).ToListAsync();
            return accountStatements;
        }

        public async Task<AccountTree> GetAccountTreeByCustomerId(int? Id)
        {
            AccountTree accountTree = await _context.AccountTree.FirstOrDefaultAsync(a=>a.Id == Id);
            return accountTree;
        }
        public async Task Update(int Id, Customer customer)
        {
            
            Customer oldCustomer = await GetCustomerById(Id);
            AccountTree accountTree = await GetAccountTreeByCustomerId(oldCustomer.AccountTree_Id);
            oldCustomer.Name = customer.Name;
            accountTree.Acc_Name = customer.Name;
            oldCustomer.Phone_Number = customer.Phone_Number;
            oldCustomer.Adress = customer.Adress;
            oldCustomer.Email = customer.Email;
            

            await _context.SaveChangesAsync();

        }

        public async Task Remove(int Id)
        {
            Customer customer = await GetCustomerById(Id);
            AccountTree accountTree = await GetAccountTreeByCustomerId(customer.AccountTree_Id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            _context.AccountTree.Remove(accountTree);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerAccountStatement> AddPayment(decimal paid, int customerId)
        {

            CustomerAccountStatement customerPayment = new CustomerAccountStatement()
            {
                Date = DateTime.Now,
                Total_Cost = 0,
                Paid = paid,
                Remainder = 0,
                Customer_Id = customerId
            };

            await _context.CustomerAccountStatements.AddAsync(customerPayment);
            await _context.SaveChangesAsync();

            return customerPayment;

        }

        public async Task<List<DailyRestrictions>> GetDailyRestrictionByAccountId(int Id, DateTime from, DateTime to)
        {
            List<DailyRestrictions> dailyRestrictions = await _context.DailyRestrictions
                                                        .Where(r=>r.AccountTree_Id==Id)
                                                        .Where(r => r.Date <= to && r.Date >= from)
                                                        .ToListAsync();
            return dailyRestrictions;
        }

        public async Task<int> GetLastRestriction()
        {
            DailyRestrictions lastRestriction = await _context.DailyRestrictions.OrderBy(r => r.Date).LastOrDefaultAsync();
            int restrictionNumber = int.Parse(lastRestriction.Number);
            return restrictionNumber;
        }

        public async Task SavingDailyRestriction(DailyRestrictions dailyRestrictionModel)
        {
            int lastResNumber =await GetLastRestriction();
            DailyRestrictions dailyRestriction = new DailyRestrictions();

            dailyRestriction.AccountTree_Id = dailyRestrictionModel.AccountTree_Id;
            dailyRestriction.Date = dailyRestrictionModel.Date;
            dailyRestriction.Statement = dailyRestrictionModel.Statement;
            dailyRestriction.Money_Amount = dailyRestrictionModel.Money_Amount;
            dailyRestriction.Number = (lastResNumber +1).ToString();
            dailyRestriction.Type = dailyRestrictionModel.Type;

            if (dailyRestrictionModel.Type == "Debtor")
            {
                dailyRestriction.Account = "Company";
            }
            else
            {
                dailyRestriction.Account = "Safes";
            }

            await _context.DailyRestrictions.AddAsync(dailyRestriction);
            await _context.SaveChangesAsync();
        }

    }
}

