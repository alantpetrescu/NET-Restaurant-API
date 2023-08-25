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
    }
}
