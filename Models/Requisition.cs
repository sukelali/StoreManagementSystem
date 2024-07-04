namespace StoreManagementSystem.Models
{
    public class Requisition : BaseModel
    {
        

        public required string Number { get; set; }

        public required string Status { get; set; } // Drafts, Approved, Dispatched

        
        public string? RefNumber { get; set; }


        public virtual ICollection<RequisitionItem>? RequisitionItems { get; set; }


    }
}
