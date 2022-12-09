using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.AccountTreeRepo;

namespace Small_ERP.Controllers
{
    public class AccountTreeController : Controller
    {
        private readonly IAccountTreeRepository AccountTreeRepo;
        public AccountTreeController(IAccountTreeRepository AccountTreeRepo)
        {
            this.AccountTreeRepo = AccountTreeRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DiplayAllAccounts()
        {
            List<AccountTree> accountTrees = await AccountTreeRepo.GetAllAccounts();
            return View(accountTrees);
        }

        public async Task<IActionResult> DiplayAllSafes()
        {
            List<Safes> safes = await AccountTreeRepo.GetAllSafes();
            return View(safes);
        }

        public async Task<IActionResult> DiplayAllDailyRestrictions()
        {
            List<DailyRestrictions> dailyRestrictions = await AccountTreeRepo.GetAllDailyRestrictions();
            return View(dailyRestrictions);
        }
    }
}
