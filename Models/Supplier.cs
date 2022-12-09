using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        [ForeignKey("AccountTree")]
        public int? AccountTree_Id { get; set; }

        public virtual List<PurchasesBillHeader>? PurchasesBillHeader { get; set; }
        public virtual List<SupplierAccountStatement>? SupplierAccountStatement { get; set; }

        public virtual AccountTree? AccountTree { get; set; }
    }
}
