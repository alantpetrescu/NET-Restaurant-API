namespace NET_Restaurant_API.Models
{
    public class RestaurantRecipe
    {
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
