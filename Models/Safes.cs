using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class Safes
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Money_Amount { get; set; }

        [ForeignKey("AccountTree")]
        public int? AccountTree_Id { get; set; }

        public virtual AccountTree? AccountTree { get; set; }
    }
}
