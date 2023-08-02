using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models
{
	public class Ingredient
	{
        [Required]
		public int Id { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
	}
}

