using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Services.EmployeeService;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantController : Controller
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("getRestaurants")]
        public IActionResult GetRestaurants()
        {
            return Json(_restaurantService.GetAll());
        }


        [HttpPost("create")]
        public IActionResult Create(RestaurantDTO restaurantDTO)
        {
            Restaurant restaurant = _restaurantService.Create(restaurantDTO);
            return Ok(restaurant);
        }

        [HttpPost("delete/{restaurantId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid restaurantId)
        {
            await _restaurantService.Delete(restaurantId);
            return Ok(_restaurantService.GetAll());
        }
    }
}
