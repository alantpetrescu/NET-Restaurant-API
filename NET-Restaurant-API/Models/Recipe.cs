using System;
using System.ComponentModel.DataAnnotations;
using NET_Restaurant_API.Models.Base;

namespace NET_Restaurant_API.Models
{
    public class Recipe : BaseEntity
	{
        [StringLength(100)]
		public string Name { get; set; }
        
        public IList<RestaurantRecipe> RestaurantRecipes { get; set; }
        public IList<RecipeIngredient> RecipeIngredients { get; set; }
	}
}

