using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Item")]
        public int? Item_Id { get; set; }

        public virtual Item? Item { get; set; }

    }
}
