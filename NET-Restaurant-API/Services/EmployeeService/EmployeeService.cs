using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class EmployeeService
    {
        public EmployeeRepository _databaseRepository;
        public EmployeeService(EmployeeRepository databaseRepository) 
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _databaseRepository.GetAll();
        }

        public EmployeeDTO GetDataMappedByEmail(string email)
        {
            Employee employee = _databaseRepository.GetByEmail(email);
            EmployeeDTO result = new EmployeeDTO()
            {
                Id = employee.Id,
                DateCreated = employee.DateCreated,
                DateModified = employee.DateModified,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = email
            };

            return result;
        }

        public void Create(EmployeeDTO employeeDTO, RestaurantDTO restaurantDTO)
        {
           // _databaseRepository.Create(employee);
        }
    }
}
