using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class SupplierAccountStatement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Paid { get; set; }
        public decimal Remainder { get; set; }

        [ForeignKey("Supplier")]
        public int? Supplier_Id { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
