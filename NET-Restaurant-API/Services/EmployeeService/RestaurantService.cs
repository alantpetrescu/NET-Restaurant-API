using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;

namespace NET_Restaurant_API.Services.EmployeeService
{
    public class RestaurantService
    {
        public RestaurantRepository _restaurantRepository;
        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> GetAll()
        {
            List<Restaurant> listRestaurant = _restaurantRepository.GetAll().Result;

            foreach(var restaurant in listRestaurant)
            {
                System.Diagnostics.Debug.WriteLine(restaurant);
            }

            return listRestaurant;
        }

        public Restaurant Create(RestaurantDTO restaurantDTO)
        {
            Restaurant restaurant = new Restaurant
            {
                Id = restaurantDTO.Id,
                DateCreated = restaurantDTO.DateCreated,
                DateModified = restaurantDTO.DateModified,
                Title = restaurantDTO.Title,
                RestaurantRecipes = null
            };
            // _databaseRepository.Create(employee);
            _restaurantRepository.Create(restaurant);
            _restaurantRepository.Save();

            return restaurant;
        }

        public async Task Delete(Guid restaurantId) 
        {
            var courseToDelete = await _restaurantRepository.FindByIdAsync(restaurantId);
            _restaurantRepository.Delete(courseToDelete);
            await _restaurantRepository.SaveAsync();
        }
    }
}
