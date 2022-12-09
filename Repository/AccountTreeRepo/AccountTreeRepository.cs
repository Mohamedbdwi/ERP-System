using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;

namespace Small_ERP.Repository.AccountTreeRepo
{
    public class AccountTreeRepository: IAccountTreeRepository
    {
        private readonly ERPDbContext _context;

        public AccountTreeRepository(ERPDbContext db)
        {
            _context = db;

        }
        public async Task<List<AccountTree>> GetAllAccounts()
        {
            List<AccountTree> accountTrees = await _context.AccountTree.ToListAsync();
            return accountTrees;
        }

        public async Task<List<Safes>> GetAllSafes()
        {
            List<Safes> safes = await _context.Safes.Include(s => s.AccountTree).ToListAsync();
            return safes;
        }

        public async Task<List<DailyRestrictions>> GetAllDailyRestrictions()
        {
            List<DailyRestrictions> dailyRestrictions = await _context.DailyRestrictions.Include(s => s.AccountTree).ToListAsync();
            return dailyRestrictions;
        }
    }
}
