using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models
{
    public class ItemCategory : BaseModel
    {

        public long? ParentCategoryId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string GroupCode { get; set; }

        public bool IsActive { get; set; } = true;



        [ForeignKey(nameof(ParentCategoryId))]
        public virtual ItemCategory? ParentCategory { get; set; }


        public virtual ICollection<ItemCategory>? ChildCategories { get; set; }
    }
}
