using Small_ERP.Models;

namespace Small_ERP.Repository.ItemRepo
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItems();
        Task Insert(Item newItem);
        Task<Item> GetItemById(int Id);
        Task Update(int Id, Item item);
        Task Remove(int Id);
        Task<List<ItemMovement>> GetItemsMovement(int itemId, DateTime from, DateTime to);
    }
}
