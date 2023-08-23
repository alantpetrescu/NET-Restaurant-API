using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
	public class Restaurant : BaseEntity
	{
		[StringLength(100)]
		public string Title { get; set; }

		public Manager? Manager { get; set; }
		public IList<RestaurantRecipe>? RestaurantRecipes { get; set; }

        public override string ToString()
        {
			return "Restaurant " + Title + " with id " + Id + " has the manager: \n" + Manager;
        }
    }	
}