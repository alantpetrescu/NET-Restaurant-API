namespace NET_Restaurant_API.Models.DTOs.RecipeIngredientDTO
{
    public class RecipeIngredientDTO
    {
        public int Quantity { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
