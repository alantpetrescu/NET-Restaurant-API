using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
	public class Employee : BaseEntity
	{
		[StringLength(100)]
		public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
		[Range(0, 100)]
		public int Age { get; set; }
		public string? Email { get; set; }
		public Guid RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; } = null!;
    }
}