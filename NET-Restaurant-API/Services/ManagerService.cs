using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services
{
    public class ManagerService
    {
        public ManagerRepository _managerRepository;
        public RestaurantRepository _restaurantRepository;
        public IMapper _mapper;
        public ManagerService(ManagerRepository managerRepository, RestaurantRepository restaurantRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public ManagerResponseDTO GetManager(Guid managerId)
        {
            Manager manager = _managerRepository.Get(managerId);
            ManagerResponseDTO managerResponseDTO = _mapper.Map<ManagerResponseDTO>(manager);

            return managerResponseDTO;
        }

        public async Task<List<ManagerResponseDTO>> GetAll()
        {
            List<Manager> managers = await _managerRepository.GetAll();
            List<ManagerResponseDTO> managersResponseDTO = _mapper.Map<List<ManagerResponseDTO>>(managers);

            return managersResponseDTO;
        }

        public ManagerResponseDTO Create(ManagerCreateDTO managerCreateDTO)
        {
            Manager manager = _mapper.Map<Manager>(managerCreateDTO);

            var restaurant = _restaurantRepository.FindById(managerCreateDTO.RestaurantId);
            restaurant.Manager = manager;
            //            System.Diagnostics.Debug.WriteLine(restaurant);

            _managerRepository.Create(manager);
            _managerRepository.Save();
            //            _restaurantRepository.Save();
            //System.Diagnostics.Debug.WriteLine(restaurant);

            ManagerResponseDTO managerResponseDTO = _mapper.Map<ManagerResponseDTO>(manager);
            return managerResponseDTO;
        }

        public ManagerResponseDTO Update(Guid managerId, ManagerCreateDTO managerCreateDTO)
        {
            Manager firstManager = _managerRepository.FindById(managerId);

            var firstRestaurant = _restaurantRepository.FindById(firstManager.RestaurantId);
            firstRestaurant.Manager = null;
            //firstRestaurant.DateModified = DateTime.UtcNow;

            Manager manager = _mapper.Map<Manager>(managerCreateDTO);
            manager.Id = managerId;
            //manager.DateModified = DateTime.UtcNow;

            var restaurant = _restaurantRepository.FindById(managerCreateDTO.RestaurantId);
            restaurant.Manager = manager;
            //restaurant.DateModified = DateTime.UtcNow;
            //            System.Diagnostics.Debug.WriteLine(restaurant);

            _restaurantRepository.Save();
            _managerRepository.Update(manager);
            _managerRepository.Save();
            //            _restaurantRepository.Save();
            //System.Diagnostics.Debug.WriteLine(restaurant);

            ManagerResponseDTO managerResponseDTO = _mapper.Map<ManagerResponseDTO>(manager);
            return managerResponseDTO;
        }

        public async Task Delete(Guid managerId)
        {
            var managerToDelete = await _managerRepository.FindByIdAsync(managerId);
            _managerRepository.Delete(managerToDelete);
            await _managerRepository.SaveAsync();
        }
    }
}
