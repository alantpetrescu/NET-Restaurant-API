using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class RecipeIngredientRepository : GenericRepository<RecipeIngredient>
    {
        public RecipeIngredientRepository(AppDBContext context) : base(context)
        {

        }
    }
}
