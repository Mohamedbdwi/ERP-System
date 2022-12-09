using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class PurchasesBillHeader
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Paid { get; set; }
        public decimal Remainder { get; set; }

        [ForeignKey("Supplier")]
        public int? Supplier_Id { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual List<PurchasesBillDetails>? PurchasesBillDetails { get; set; }
    }
}
