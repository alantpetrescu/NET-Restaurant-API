using NET_Restaurant_API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models
{
    public class Manager : BaseEntity
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Revenue { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public override string ToString()
        {
            return "Manager " + FirstName + LastName + " with id " + Id;
        }
    }
}
