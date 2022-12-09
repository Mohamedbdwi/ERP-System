using Small_ERP.Models;

namespace Small_ERP.Repository.StoreRepo
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStores();
        Task<Store> GetStoreById(int id);
    }
}
