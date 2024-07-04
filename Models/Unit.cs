using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Models
{
    public class Unit : BaseModel
    {

        public required string Symbol { get; set; }

        public required string Name { get; set; }    

    }
}
