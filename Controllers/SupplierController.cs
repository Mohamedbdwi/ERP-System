using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.CustomerRepo;
using Small_ERP.Repository.SupplierRepo;

namespace Small_ERP.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository supplierRepo;

        public SupplierController(ISupplierRepository supplierRepo)
        {
            this.supplierRepo = supplierRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Supplier> suppliers = await supplierRepo.GetSuppliers();
            return View(suppliers);
        }

        public async Task<IActionResult> GetAllSuppliers()
        {
            List<Supplier> suppliers = await supplierRepo.GetSuppliers();
            return Ok(suppliers);
        }

        public async Task<IActionResult> DisplayAccountStatement()
        {
            ViewBag.supplierDropDownList = await supplierRepo.GetSuppliers();

            return View();
        }

        public async Task<IActionResult> GetAccountStatementBySupplier(int id)
        {
            List<SupplierAccountStatement> suppliers = await supplierRepo.GetAccountStatementById(id);
            return Ok(suppliers);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Supplier newSupplier)
        {
            if (ModelState.IsValid)
            {
                await supplierRepo.Insert(newSupplier);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", newSupplier);
            }
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Supplier supplierModel = await supplierRepo.GetSupplierById(Id);
            return View(supplierModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(int Id, Supplier supplier)
        {
            if (supplier.Name != null)
            {

                await supplierRepo.Update(Id, supplier);

                return RedirectToAction("Index");

            }
            return View("Edit", supplier);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await supplierRepo.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymnet(decimal paid, int SupplierId)
        {

            SupplierAccountStatement supplierPaid = await supplierRepo.AddPayment(paid, SupplierId);
            return Ok(supplierPaid);
        }
    }
}
