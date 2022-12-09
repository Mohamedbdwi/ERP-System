using System.ComponentModel.DataAnnotations.Schema;

namespace Small_ERP.Models
{
    public class CostCenter
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [ForeignKey("ParentCostCenter")]
        public int? ParentCostCenter_Id { get; set; }
        public virtual CostCenter ParentCostCenter { get; set; }
        public virtual List<CostCenter> Branches { get; set; }
    }
}
