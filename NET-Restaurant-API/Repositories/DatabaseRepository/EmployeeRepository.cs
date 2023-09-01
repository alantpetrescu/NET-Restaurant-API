using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(AppDBContext context) : base(context)
        {

        }

        public Employee Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

        public Employee GetByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
