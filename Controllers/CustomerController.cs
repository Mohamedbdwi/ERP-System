using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.AccountTreeRepo;
using Small_ERP.Repository.CustomerRepo;

namespace Small_ERP.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepo;
        private readonly IAccountTreeRepository accountTreeRepo;

        public CustomerController(ICustomerRepository customerRepo, IAccountTreeRepository accountTreeRepo)
        {
            this.customerRepo = customerRepo;
            this.accountTreeRepo = accountTreeRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await customerRepo.GetCustomers();
            return View(customers);
        }

        public async Task<IActionResult> GetCustomers()
        {
            List<Customer> customers = await customerRepo.GetCustomers();
            return Ok(customers);
        }


        public async Task<IActionResult> DisplayAccountStatement()
        {
            ViewBag.customerDropDownList = await customerRepo.GetCustomers();

            return View();
        }

        public async Task<IActionResult> GetAccountStatementByCustomer(int id)
        {
            List<CustomerAccountStatement> customers = await customerRepo.GetAccountStatementById(id);
            return Ok(customers);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                await customerRepo.Insert(newCustomer);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", newCustomer);
            }
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Customer customerModel = await customerRepo.GetCustomerById(Id);
            return View(customerModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(int Id, Customer customer)
        {
            if (customer.Name != null)
            {

                await customerRepo.Update(Id, customer);

                return RedirectToAction("Index");

            }
            return View("Edit", customer);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await customerRepo.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymnet(decimal paid, int customerId)
        {

            CustomerAccountStatement customerPaid = await customerRepo.AddPayment(paid, customerId);
            return Ok(customerPaid);
        }

        public async Task<IActionResult> TreeAccountStatement()
        {
            ViewBag.accountsDropDownList = await accountTreeRepo.GetAllAccounts();
            return View();
        }
        public async Task<IActionResult> GetDailyRestrictionByAccountId(int Id, DateTime from, DateTime to)
        {
            List<DailyRestrictions> dailyRestrictions = await customerRepo.GetDailyRestrictionByAccountId(Id, from, to);
            return Ok(dailyRestrictions);
        }

        public async Task<IActionResult> AddDailyRestriction()
        {
            ViewBag.accountsDropDownList = await accountTreeRepo.GetAllAccounts();
            return View();
        }
        public async Task<IActionResult> SavingDailyRestriction(DailyRestrictions dailyRestrictionModel)
        {
            await customerRepo.SavingDailyRestriction(dailyRestrictionModel);
            return RedirectToAction("GetDailyRestrictionByAccountId");
        }
    }
}


