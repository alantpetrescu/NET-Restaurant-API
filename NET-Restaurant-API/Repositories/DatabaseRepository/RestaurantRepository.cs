using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class RestaurantRepository : GenericRepository<Restaurant>
    {
        public RestaurantRepository(AppDBContext context) : base(context)
        {

        }

        public Restaurant Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _table.ToListAsync();
        }
    }
}
