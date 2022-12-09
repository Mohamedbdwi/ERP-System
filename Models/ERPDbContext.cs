using Microsoft.EntityFrameworkCore;

namespace Small_ERP.Models
{
    public class ERPDbContext:DbContext
    {
        private readonly IConfiguration configuration;
        public ERPDbContext()
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }


        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchasesBillHeader> PurchasesBillHeaders { get; set; }
        public DbSet<PurchasesBillDetails> PurchasesBillDetails { get; set; }

        public DbSet<SupplierAccountStatement> SupplierAccountStatements { get; set; }
        public DbSet<CustomerAccountStatement> CustomerAccountStatements { get; set; }

        public DbSet<ItemMovement> ItemMovements { get; set; }

        public DbSet<AccountTree> AccountTree { get; set; }
        public DbSet<Safes> Safes { get; set; }
        public DbSet<DailyRestrictions> DailyRestrictions { get; set; }

        public DbSet<CostCenter> CostCenter { get; set; }


        public ERPDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SEOFCOF\\SQLEXPRESS;Database=SmallERP;Integrated Security=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
