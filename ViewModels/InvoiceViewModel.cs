using Small_ERP.Models;

namespace Small_ERP.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Customer_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Paid { get; set; }
        public decimal Remainder { get; set; }


        public List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
