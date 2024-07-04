using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Models
{
    public class Requisition : BaseModel
    {


        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        public required string Number { get; set; }

        public required string Status { get; set; } // Drafts, Dispatched

        public string? RefNumber { get; set; }

        public virtual IList<RequisitionItem> RequisitionItems { get; set; } = new List<RequisitionItem>();


    }
}
