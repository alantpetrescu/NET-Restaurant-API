using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class ManagerService
    {
        public ManagerRepository _managerRepository;
        public RestaurantRepository _restaurantRepository;
        public ManagerService(ManagerRepository managerRepository, RestaurantRepository restaurantRepository)
        {
            _managerRepository = managerRepository;
            _restaurantRepository = restaurantRepository;
        }

        public Manager GetManager(Guid managerId)
        {
            return _managerRepository.Get(managerId);
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _managerRepository.GetAll();
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

            _managerRepository.Create(manager);
            _managerRepository.Save();
            _restaurantRepository.Save();
            System.Diagnostics.Debug.WriteLine(restaurant);

            return manager;
        }

        public async Task Delete(Guid managerId)
        {
            var managerToDelete = await _managerRepository.FindByIdAsync(managerId);
            _managerRepository.Delete(managerToDelete);
            await _managerRepository.SaveAsync();
        }
    }
}
