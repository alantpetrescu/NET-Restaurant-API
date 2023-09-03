using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class RecipeRepository : GenericRepository<Recipe>
    {
        public RecipeRepository(AppDBContext context) : base(context)
        {
        }

        public Recipe Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

        public List<Ingredient> GetIngredientsFromRecipe(String recipeName)
        {
            return _context.Ingredients
                .Where(r => r.RecipeIngredients.Any(ri => ri.Recipe.Name == recipeName))
                .ToList();
        }
    }
}
