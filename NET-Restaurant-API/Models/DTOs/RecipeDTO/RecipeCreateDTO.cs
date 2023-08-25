using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs.RecipeDTO
{
    public class RecipeCreateDTO
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
