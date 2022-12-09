using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;
using System.Drawing;

namespace Small_ERP.Repository.ItemRepo
{
    public class ItemRepository:IItemRepository
    {
        private readonly ERPDbContext _context;

        public ItemRepository(ERPDbContext db)
        {
            _context = db;
        }
        public async Task<List<Item>> GetItems()
        {
            List<Item> allItems = await _context.Items.ToListAsync();
            return allItems;
        }

        public async Task Insert(Item newItem)
        {
            await _context.AddAsync(newItem);
            await _context.SaveChangesAsync();

            Store storeItem = new Store() { Item_Id = newItem.Id,
                                            Quantity=0
                                           };

            await _context.AddAsync(storeItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetItemById(int Id)
        {
            Item item = await _context.Items.FirstOrDefaultAsync(i => i.Id == Id);
            return item;
        }

        public async Task Update(int Id, Item item)
        {
            Item oldItem = await GetItemById(Id);
            oldItem.Name = item.Name;
            oldItem.Purchasing_Price = item.Purchasing_Price;
            oldItem.Selling_Price = item.Selling_Price;
            oldItem.Start_Period_Balance = item.Start_Period_Balance;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(int Id)
        {
            Item item = await GetItemById(Id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemMovement>> GetItemsMovement(int itemId, DateTime from, DateTime to)
        {
            List<ItemMovement> itemsMovement = await _context.ItemMovements.Where(i => i.Item_Id == itemId)
                                                                           .Where(i => i.Date <= to && i.Date >= from)
                                                                           .ToListAsync();
            return itemsMovement;
        }

    }
}
