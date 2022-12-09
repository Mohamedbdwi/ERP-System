using Small_ERP.Models;

namespace Small_ERP.Repository.AccountTreeRepo
{
    public interface IAccountTreeRepository
    {
        Task<List<AccountTree>> GetAllAccounts();
        Task<List<Safes>> GetAllSafes();
        Task<List<DailyRestrictions>> GetAllDailyRestrictions();
    }
}
