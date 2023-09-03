using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class IngredientRepository : GenericRepository<Ingredient>, IDatabaseRepository<Ingredient>
    {
        public IngredientRepository(AppDBContext context) : base(context)
        {

        }

        public List<Recipe> GetRecipesContainingIngredient(String ingredientName)
        {
            return  _context.Recipes
                .Where(r => r.RecipeIngredients.Any(ri => ri.Ingredient.Name == ingredientName))
                .ToList();
        }

        public Ingredient Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

        public List<Ingredient> GetAllWithInclude()
        {
            return _table.Include(x => x.RecipeIngredients).ToList();
        }

        public Task<List<Ingredient>> GetAllWithIncludeAsync()
        {
            return _table.Include(x => x.RecipeIngredients).ToListAsync();
        }

        public List<Ingredient> GetAllWithJoin()
        {
            var result = _table.Join(_context.Recipes, ingredient => ingredient.Id, recipe => recipe.Id, (ingredient, recipe)
                => new { ingredient, recipe }).Select(obj => obj.ingredient);
            return result.ToList();
        }

        public Task<List<Ingredient>> GetAllWithJoinAsync()
        {
            var result = _table.Join(_context.Recipes, ingredient => ingredient.Id, recipe => recipe.Id, (ingredient, recipe)
                => new { ingredient, recipe }).Select(obj => obj.ingredient);
            return result.ToListAsync();
        }
    }
}
