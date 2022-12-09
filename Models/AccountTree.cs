namespace Small_ERP.Models
{
    public class AccountTree
    {
        public int Id { get; set; }
        public string Acc_Id { get; set; }
        public string Acc_Name { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Supplier? Supplier { get; set; }

        public virtual List<Safes>? Safes { get; set; }
        public virtual List<DailyRestrictions>? DailyRestrictions { get; set; }
    }
}
