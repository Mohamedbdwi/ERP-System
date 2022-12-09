using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class PurchasesBillDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Item_Cost { get; set; }


        [ForeignKey("PurchasesBillHeader")]
        public int? PurchasesBillHeader_Id { get; set; }

        [ForeignKey("Item")]
        public int? Item_Id { get; set; }

        public virtual PurchasesBillHeader? PurchasesBillHeader { get; set; }
        public virtual Item? Item { get; set; }
    }
}
