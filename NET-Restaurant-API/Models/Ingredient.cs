using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
    public class Ingredient : BaseEntity
	{
		[StringLength(100)]
		public string Name { get; set; }

		public IList<RecipeIngredient> RecipeIngredients { get; set; }
	}
}

