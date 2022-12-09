using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class CustomerAccountStatement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Paid { get; set; }
        public decimal Remainder { get; set; }

        [ForeignKey("Customer")]
        public int? Customer_Id { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
