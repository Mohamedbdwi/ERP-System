using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class DailyRestrictions
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string? Statement { get; set; }
        public DateTime Date { get; set; }
        public decimal Money_Amount { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }

        [ForeignKey("AccountTree")]
        public int? AccountTree_Id { get; set; }

        public virtual AccountTree? AccountTree { get; set; }
    }
}
