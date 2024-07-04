using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models
{
    public class Item : BaseModel
    {


        [Display(Name = "Category Name")]
        public long CategoryId {  get; set; }

        [Display(Name = "Unit")]
        public long UnitId {  get; set; }

        public required string Description { get; set;  }


        public required string GroupCode { get; set; }

        public string? Ref { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual ItemCategory? Category { get; set; }


        [ForeignKey(nameof(UnitId))]
        public virtual Unit? Unit { get; set; }
    }
}
