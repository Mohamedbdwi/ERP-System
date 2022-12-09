using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.CustomerRepo;
using Small_ERP.Repository.InvoiceRepo;
using Small_ERP.Repository.ItemRepo;
using Small_ERP.ViewModels;

namespace Small_ERP.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository invoiceRepo;
        private readonly ICustomerRepository customerRepo;
        private readonly IItemRepository itemRepo;

        public InvoiceController(ICustomerRepository customer, IItemRepository item,IInvoiceRepository invoice)
        {
            this.invoiceRepo = invoice;
            this.customerRepo = customer;
            this.itemRepo = item;
        }

        
        public async Task<IActionResult> Index()
        {
            List<InvoiceHeader> invoices = await invoiceRepo.GetAllInvoices();
            
            return View(invoices);
        }

        [HttpGet]
        public async Task<IActionResult> InsertInvoice()
        {
            ViewBag.CustomerDropDownList = await customerRepo.GetCustomers();
            ViewBag.itemDropDownList = await itemRepo.GetItems();
            ViewBag.invoiceNumber = 1 + invoiceRepo.GetInvoiceNumber();

            return View();
        }

        public IActionResult GetItemPrice(int id)
        {
            var item = invoiceRepo.GetPrice(id);
            return Ok(item);
        }



        [HttpPost]
        public async Task<IActionResult> InsertInvoice(InvoiceViewModel invoiceModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Check your data");

            //    return View(invoiceModel);
            //}
            await invoiceRepo.CreatingInvoice(invoiceModel);
            return RedirectToAction("Index");
        }
    }
}
