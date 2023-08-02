using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
	public class Ingredient : BaseEntity
	{
        [Required]
		public int Id { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
	}
}

