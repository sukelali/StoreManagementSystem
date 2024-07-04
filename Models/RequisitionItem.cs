using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models
{
    public class RequisitionItem : BaseModel
    {

        public long RequisitionId { get; set; }


        [Required(ErrorMessage = "Item Field is required")]
        public long ItemId { get; set; }

        public required string ItemDescription { get; set; }

        public float Quantity { get; set; }

        public string? LineRef { get; set; }

        [ForeignKey(nameof(RequisitionId))]
        public virtual Requisition? Requisition { get; set; }

        [ForeignKey(nameof(ItemId))]    
        public virtual Item? Item { get; set; }


    }
}
