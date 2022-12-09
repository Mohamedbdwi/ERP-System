using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.StoreRepo;

namespace Small_ERP.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository storeRepo;

        public StoreController(IStoreRepository storeRepo)
        {
            this.storeRepo = storeRepo;
        }
        public async Task<IActionResult> Index()
        {
            List<Store> stores = await storeRepo.GetStores();
            return View(stores);
        }

        public async Task<IActionResult> GetStoreById(int id)
        {
            Store store = await storeRepo.GetStoreById(id);
            return Ok(store);
        }
    }
}
