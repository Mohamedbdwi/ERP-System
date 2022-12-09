using Microsoft.AspNetCore.Mvc;
using Small_ERP.Repository.ItemRepo;
using Small_ERP.Repository.PurchaseBillRepo;
using Small_ERP.Repository.SupplierRepo;
using Small_ERP.ViewModels;

namespace Small_ERP.Controllers
{
    public class PurchaseBillController : Controller
    {
        private readonly ISupplierRepository supplierRepo;
        private IItemRepository itemRepo;
        private readonly IPurchaseBillRepository billRepo;

        public PurchaseBillController(ISupplierRepository supplierRepo, IItemRepository itemRepo,IPurchaseBillRepository billRepo)
        {
            this.supplierRepo = supplierRepo;
            this.itemRepo = itemRepo;
            this.billRepo = billRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InsertPurchaseBill()
        {
            ViewBag.SupplierDropDownList = await supplierRepo.GetSuppliers();
            ViewBag.itemDropDownList = await itemRepo.GetItems();
            ViewBag.billNumber = 1 + billRepo.GetBillNumber();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPurchaseBill(PurchaseBillViewModel billModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Check your data");

            //    return View(invoiceModel);
            //}
            await billRepo.CreatingBill(billModel);
            return RedirectToAction("Index","Item");
        }
    }
}
