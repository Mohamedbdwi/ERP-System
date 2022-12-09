using Small_ERP.Models;

namespace Small_ERP.ViewModels
{
    public class PurchaseBillViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Supplier_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Paid { get; set; }
        public decimal Remainder { get; set; }


        public List<PurchasesBillDetails> PurchasesBillDetails { get; set; }
        public List<Store> store { get; set; }
    }
}
