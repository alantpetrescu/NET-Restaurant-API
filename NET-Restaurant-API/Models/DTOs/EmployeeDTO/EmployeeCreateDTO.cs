using NET_Restaurant_API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs
{
    public class EmployeeCreateDTO
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
