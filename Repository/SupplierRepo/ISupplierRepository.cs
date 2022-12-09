using Small_ERP.Models;

namespace Small_ERP.Repository.SupplierRepo
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers();
        
        Task<List<SupplierAccountStatement>> GetAccountStatementById(int id);
        Task Insert(Supplier newSupplier);
        Task<Supplier> GetSupplierById(int Id);
        Task Update(int Id, Supplier supplier);
        Task Remove(int Id);
        Task<SupplierAccountStatement> AddPayment(decimal paid, int SupplierId);
    }
}
