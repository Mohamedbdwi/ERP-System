using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Item_Cost { get; set; }


        [ForeignKey("InvoiceHeader")]
        public int? InvoiceHeader_Id { get; set; }

        [ForeignKey("Item")]
        public int? Item_Id { get; set; }

        public virtual InvoiceHeader? InvoiceHeader { get; set; }
        public virtual Item? Item { get; set; }

    }
}
