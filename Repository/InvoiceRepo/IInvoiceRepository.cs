using Small_ERP.Models;
using Small_ERP.ViewModels;

namespace Small_ERP.Repository.InvoiceRepo
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceHeader>> GetAllInvoices();
        
        Item GetPrice(int id);
        int GetInvoiceNumber();

        Task CreatingInvoice(InvoiceViewModel invoiceModel);
    }
}
