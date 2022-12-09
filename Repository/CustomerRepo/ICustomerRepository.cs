using Small_ERP.Models;

namespace Small_ERP.Repository.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task Insert(Customer newCustomer);
        Task<Customer> GetCustomerById(int Id);
        Task<List<CustomerAccountStatement>> GetAccountStatementById(int id);
        Task Update(int Id, Customer customer);
        Task Remove(int Id);
        Task<CustomerAccountStatement> AddPayment(decimal paid, int customerId);
        Task<List<DailyRestrictions>> GetDailyRestrictionByAccountId(int Id, DateTime from, DateTime to);
        Task SavingDailyRestriction(DailyRestrictions dailyRestrictionModel);
    }
}
