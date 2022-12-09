using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class ItemMovement
    {
        public int Id { get; set; }
        public string Movement_Type { get; set; }
        public int Quantity { get; set; }
        public string Bill_Number { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Item")]
        public int? Item_Id { get; set; }
        public virtual Item? Item { get; set; }
    }
}
