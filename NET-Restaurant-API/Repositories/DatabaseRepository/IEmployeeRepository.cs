using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        List<Employee> GetAllWithInclude();
        Task<List<Employee>> GetAllWithIncludeAsync();
        List<Employee> GetAllWithJoin();
        Task<List<Employee>> GetAllWithJoinAsync();
    }
}
