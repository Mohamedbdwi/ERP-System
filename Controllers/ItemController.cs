using Microsoft.AspNetCore.Mvc;
using Small_ERP.Models;
using Small_ERP.Repository.ItemRepo;

namespace Small_ERP.Controllers
{
    public class ItemController : Controller
    {

        private readonly IItemRepository itemRepo;

        public ItemController(IItemRepository itemRepo)
        {
            this.itemRepo = itemRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Item> items = await itemRepo.GetItems();
            return View(items);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Item newItem)
        {
            if (ModelState.IsValid)
            {
                await itemRepo.Insert(newItem);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", newItem);
            }
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Item itemModel = await itemRepo.GetItemById(Id);
            return View(itemModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(int Id, Item item)
        {
            if (item.Name != null)
            {

                await itemRepo.Update(Id, item);

                return RedirectToAction("Index");

            }
            return View("Edit", item);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await itemRepo.Remove(Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ItemMovements()
        {
            ViewBag.itemDropDownList = await itemRepo.GetItems();

            return View();
        }

        public async Task<IActionResult> GetItemMovement(int itemId, DateTime from, DateTime to)
        {
            List<ItemMovement> movements = await itemRepo.GetItemsMovement(itemId, from, to);
            return Ok(movements);
        }
    }
}
