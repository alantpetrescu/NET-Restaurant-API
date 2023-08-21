using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class ManagerService
    {
        public ManagerRepository _databaseRepository;
        public RestaurantRepository _restaurantRepository;
        public ManagerService(ManagerRepository databaseRepository, RestaurantRepository restaurantRepository)
        {
            _databaseRepository = databaseRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _databaseRepository.GetAll();
        }

        public Manager Create(ManagerDTO managerDTO)
        {
            var manager = new Manager()
            {
                Id = managerDTO.Id,
                DateCreated = managerDTO.DateCreated,
                DateModified = managerDTO.DateModified,
                FirstName = managerDTO.FirstName,
                LastName = managerDTO.LastName,
                Age = managerDTO.Age,
                Email = managerDTO.Email,
                Revenue = managerDTO.Revenue,
                RestaurantId = managerDTO.RestaurantId
            };

            var restaurant = _restaurantRepository.FindById(managerDTO.RestaurantId);
            restaurant.Manager = manager;
            System.Diagnostics.Debug.WriteLine(restaurant);

            _databaseRepository.Create(manager);
            _databaseRepository.Save();
            _restaurantRepository.Save();
            System.Diagnostics.Debug.WriteLine(restaurant);

            return manager;
        }
    }
}
