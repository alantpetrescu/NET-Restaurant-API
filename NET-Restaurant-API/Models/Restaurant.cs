using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
	public class Restaurant : BaseEntity
	{
        [Required]
        public int Id { get; set; }
		[StringLength(100)]
		public string Title { get; set; }
	}
}