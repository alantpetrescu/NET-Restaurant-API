using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class EmployeeRepository : GenericRepository<Employee>, IDatabaseRepository<Employee>
    {
        public EmployeeRepository(AppDBContext context) : base(context)
        {

        }

        public List<Employee> GetAllWithInclude()
        {
            return _table.Include(x => x.Restaurant).ToList();
        }

        public Task<List<Employee>> GetAllWithIncludeAsync()
        {
            return _table.Include(x => x.Restaurant).ToListAsync();
        }

        public List<Employee> GetAllWithJoin()
        {
            var result = _table.Join(_context.Restaurants, employee => employee.RestaurantId, restaurant => restaurant.Id, (employee, restaurant)
                => new { employee, restaurant }).Select(obj => obj.employee);
            return result.ToList();
        }

        public Task<List<Employee>> GetAllWithJoinAsync()
        {
            var result = _table.Join(_context.Restaurants, employee => employee.RestaurantId, restaurant => restaurant.Id, (employee, restaurant)
                => new { employee, restaurant }).Select(obj => obj.employee);
            return result.ToListAsync();
        }
    }
}
