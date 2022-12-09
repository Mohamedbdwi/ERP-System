namespace Small_ERP.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Purchasing_Price { get; set; }
        public decimal Selling_Price { get; set; }
        public int Start_Period_Balance { get; set; }

        public virtual List<InvoiceDetails>? InvoiceDetails { get; set; }
        public virtual List<PurchasesBillDetails>? PurchasesBillDetails { get; set; }
        public virtual List<Store>? Store { get; set; }
        public virtual List<ItemMovement>? ItemMovement { get; set; }
    }
}
