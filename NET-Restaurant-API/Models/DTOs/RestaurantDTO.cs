using NET_Restaurant_API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs
{
    public class RestaurantDTO : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }
        public Guid ManagerId { get; set; }
    }
}