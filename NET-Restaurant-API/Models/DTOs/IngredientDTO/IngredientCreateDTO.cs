using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs.IngredientDTO
{
    public class IngredientCreateDTO
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
