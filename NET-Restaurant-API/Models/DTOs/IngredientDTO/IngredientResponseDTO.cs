using NET_Restaurant_API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs.IngredientDTO
{
    public class IngredientResponseDTO : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
