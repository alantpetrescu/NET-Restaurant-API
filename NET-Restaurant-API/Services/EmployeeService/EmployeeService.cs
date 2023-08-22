using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class EmployeeService
    {
        public EmployeeRepository _employeeRepository;
        public RestaurantRepository _restaurantRepository;
        public EmployeeService(EmployeeRepository databaseRepository, RestaurantRepository restaurantRepository) 
        {
            _employeeRepository = databaseRepository;
            _restaurantRepository = restaurantRepository;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _employeeRepository.Get(employeeId);
        }

        public Employee GetEmployeeByEmail(String email)
        {
            return _employeeRepository.GetByEmail(email);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public EmployeeDTO GetDataMappedByEmail(string email)
        {
            Employee employee = _employeeRepository.GetByEmail(email);
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

        public Employee Create(EmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                Id = employeeDTO.Id,
                DateCreated = employeeDTO.DateCreated,
                DateModified = employeeDTO.DateModified,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Age = employeeDTO.Age,
                Email = employeeDTO.Email,
                RestaurantId = employeeDTO.RestaurantId
            };

            System.Diagnostics.Debug.WriteLine(employee);

            _employeeRepository.Create(employee);
            _employeeRepository.Save();

            return employee;
        }

        public async Task Delete(Guid employeeId)
        {
            var employeeToDelete = await _employeeRepository.FindByIdAsync(employeeId);
            _employeeRepository.Delete(employeeToDelete);
            await _employeeRepository.SaveAsync();
        }
    }
}
