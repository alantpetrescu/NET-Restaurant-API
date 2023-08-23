using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models.DTOs
{
    public class ManagerResponseDTO : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Revenue { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
