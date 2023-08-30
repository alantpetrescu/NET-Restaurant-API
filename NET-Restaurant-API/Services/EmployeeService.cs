using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using System.Diagnostics;

namespace NET_Restaurant_API.Services
{
    public class EmployeeService
    {
        public EmployeeRepository _employeeRepository;
        public RestaurantRepository _restaurantRepository;
        public IMapper _mapper;
        public EmployeeService(EmployeeRepository databaseRepository, RestaurantRepository restaurantRepository, IMapper mapper)
        {
            _employeeRepository = databaseRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public EmployeeResponseDTO GetEmployeeById(Guid employeeId)
        {
            Employee employee = _employeeRepository.Get(employeeId);
            EmployeeResponseDTO employeeResponseDTO = _mapper.Map<EmployeeResponseDTO>(employee);

            return employeeResponseDTO;
        }

        public EmployeeResponseDTO GetEmployeeByEmail(string email)
        {
            Employee employee = _employeeRepository.GetByEmail(email);
            EmployeeResponseDTO employeeResponseDTO = _mapper.Map<EmployeeResponseDTO>(employee);

            return employeeResponseDTO;
        }

        public async Task<List<EmployeeResponseDTO>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();
            List<EmployeeResponseDTO> employeesResponseDTO = _mapper.Map<List<EmployeeResponseDTO>>(employees);

            return employeesResponseDTO;
        }

        public EmployeeResponseDTO GetDataMappedByEmail(string email)
        {
            Employee employee = _employeeRepository.GetByEmail(email);
            EmployeeResponseDTO employeeResponseDTO = _mapper.Map<EmployeeResponseDTO>(employee);

            return employeeResponseDTO;
        }

        public EmployeeResponseDTO Create(EmployeeCreateDTO employeeCreateDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeCreateDTO);

            //         System.Diagnostics.Debug.WriteLine(employee);

            _employeeRepository.Create(employee);
            _employeeRepository.Save();

            EmployeeResponseDTO employeeResponseDTO = _mapper.Map<EmployeeResponseDTO>(employee);
            return employeeResponseDTO;
        }

        public EmployeeResponseDTO Update(Guid employeeId, EmployeeCreateDTO employeeCreateDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeCreateDTO);
            employee.Id = employeeId;
            //employee.DateModified = DateTime.UtcNow;
            Debug.WriteLine("Employe DateModified: " + employee.DateModified);

            //         System.Diagnostics.Debug.WriteLine(employee);

            _employeeRepository.Update(employee);
            _employeeRepository.Save();

            EmployeeResponseDTO employeeResponseDTO = _mapper.Map<EmployeeResponseDTO>(employee);
            return employeeResponseDTO;
        }

        public async Task Delete(Guid employeeId)
        {
            var employeeToDelete = await _employeeRepository.FindByIdAsync(employeeId);
            _employeeRepository.Delete(employeeToDelete);
            await _employeeRepository.SaveAsync();
        }
    }
}
