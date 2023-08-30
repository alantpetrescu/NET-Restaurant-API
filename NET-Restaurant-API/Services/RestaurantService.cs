using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services
{
    public class RestaurantService
    {
        public RestaurantRepository _restaurantRepository;
        public IMapper _mapper;
        public RestaurantService(RestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public List<RestaurantResponseDTO> GetAll()
        {
            List<Restaurant> restaurants = _restaurantRepository.GetAll().Result;
            List<RestaurantResponseDTO> restaurantsResponseDTO = _mapper.Map<List<RestaurantResponseDTO>>(restaurants);

            return restaurantsResponseDTO;
        }

        public RestaurantResponseDTO GetRestaurant(Guid restaurantId)
        {
            Restaurant restaurant = _restaurantRepository.Get(restaurantId);
            RestaurantResponseDTO restaurantResponseDTO = _mapper.Map<RestaurantResponseDTO>(restaurant);

            return restaurantResponseDTO;
        }

        public RestaurantResponseDTO Create(RestaurantCreateDTO restaurantCreateDTO)
        {
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantCreateDTO);
            // _databaseRepository.Create(employee);
            _restaurantRepository.Create(restaurant);
            _restaurantRepository.Save();

            RestaurantResponseDTO restaurantResponseDTO = _mapper.Map<RestaurantResponseDTO>(restaurant);
            return restaurantResponseDTO;
        }

        public RestaurantResponseDTO Update(Guid restaurantId, RestaurantCreateDTO restaurantCreateDTO)
        {
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantCreateDTO);
            // _databaseRepository.Create(employee);
            restaurant.Id = restaurantId;
            //restaurant.DateModified = DateTime.Now;

            _restaurantRepository.Update(restaurant);
            _restaurantRepository.Save();

            RestaurantResponseDTO restaurantResponseDTO = _mapper.Map<RestaurantResponseDTO>(restaurant);
            return restaurantResponseDTO;
        }

        public async Task Delete(Guid restaurantId) 
        {
            var restaurantToDelete = await _restaurantRepository.FindByIdAsync(restaurantId);
            _restaurantRepository.Delete(restaurantToDelete);
            await _restaurantRepository.SaveAsync();
        }
    }
}
