using Small_ERP.ViewModels;

namespace Small_ERP.Repository.PurchaseBillRepo
{
    public interface IPurchaseBillRepository
    {
        Task CreatingBill(PurchaseBillViewModel billModel);
        int GetBillNumber();
    }
}
