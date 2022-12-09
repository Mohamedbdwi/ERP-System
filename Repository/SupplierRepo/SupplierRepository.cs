using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;

namespace Small_ERP.Repository.SupplierRepo
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ERPDbContext _context;

        public SupplierRepository(ERPDbContext db)
        {
            _context = db;
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            List<Supplier> allSuppliers = await _context.Suppliers.ToListAsync();
            return allSuppliers;
        }

        public async Task Insert(Supplier newSupplier)
        {
            await _context.AddAsync(newSupplier);
            await _context.SaveChangesAsync();
        }

        public async Task<Supplier> GetSupplierById(int Id)
        {
            Supplier supplier = await _context.Suppliers.FirstOrDefaultAsync(i => i.Id == Id);
            return supplier;
        }

        public async Task<List<SupplierAccountStatement>> GetAccountStatementById(int id)
        {
            List<SupplierAccountStatement> accountStatements = await _context.SupplierAccountStatements.Where(s => s.Supplier_Id == id).ToListAsync();
            return accountStatements;
        }

        public async Task Update(int Id, Supplier supplier)
        {
            Supplier oldSupplier = await GetSupplierById(Id);
            oldSupplier.Name = supplier.Name;
            oldSupplier.Phone_Number = supplier.Phone_Number;
            oldSupplier.Adress = supplier.Adress;
            oldSupplier.Email = supplier.Email;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int Id)
        {
            Supplier supplier = await GetSupplierById(Id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<SupplierAccountStatement> AddPayment(decimal paid, int SupplierId)
        {

            SupplierAccountStatement supplierPayment = new SupplierAccountStatement()
            {
                Date = DateTime.Now,
                Total_Cost = 0,
                Paid = paid,
                Remainder = 0,
                Supplier_Id = SupplierId
            };

            await _context.SupplierAccountStatements.AddAsync(supplierPayment);
            await _context.SaveChangesAsync();

            return supplierPayment;

        }
    }
}
