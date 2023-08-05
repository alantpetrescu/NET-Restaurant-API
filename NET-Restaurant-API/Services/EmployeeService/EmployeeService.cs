using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Services.DemoService;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public IDatabaseRepository<Employee> _databaseRepository;
        public EmployeeService(IDatabaseRepository<Employee> databaseRepository) 
        {
            _databaseRepository = databaseRepository;
        }

        public EmployeeDTO GetDataMappedByEmail(string email)
        {
            Employee employee = ((EmployeeRepository)Convert.ChangeType(_databaseRepository, typeof(EmployeeRepository))).GetByEmail(email);
            EmployeeDTO result = new EmployeeDTO()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = email
            };

            return result;
        }
    }
}
