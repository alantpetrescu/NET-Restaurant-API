namespace NET_Restaurant_API.Models
{
    public class RecipeIngredient
    {
        public int Quantity { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
