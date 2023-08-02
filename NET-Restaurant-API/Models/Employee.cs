using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models
{
	public class Employee
	{
		[Required]
		public int Id { get; set; }
		[StringLength(100)]
		public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
		[Range(0, 100)]
		public int Age { get; set; }
	}
}

