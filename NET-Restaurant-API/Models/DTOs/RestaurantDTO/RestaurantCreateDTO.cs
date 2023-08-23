using NET_Restaurant_API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs
{
    public class RestaurantCreateDTO
    {
        [StringLength(100)]
        public string Title { get; set; }
    }
}