using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;

namespace Small_ERP.Repository.StoreRepo
{
    public class StoreRepository: IStoreRepository
    {
        private readonly ERPDbContext _context;

        public StoreRepository(ERPDbContext db)
        {
            _context = db;
        }
        public async Task<List<Store>> GetStores()
        {
            List<Store> stores = await _context.Stores.Include(i=>i.Item).ToListAsync();
            return stores;
        }

        public async Task<Store> GetStoreById(int id)
        {
            Store store = await _context.Stores.FirstOrDefaultAsync(s=>s.Item_Id == id);
            return store;
        }
    }
}
