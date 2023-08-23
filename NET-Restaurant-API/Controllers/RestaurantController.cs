using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getRestaurant/{restaurantId}")]
        public IActionResult GetRestaurant([FromRoute] Guid restaurantId)
        {
            return Ok(_restaurantService.GetRestaurant(restaurantId));
        }


        [HttpPost("create")]
        public IActionResult Create(RestaurantCreateDTO restaurantCreateDTO)
        {
            RestaurantResponseDTO restaurantResponseDTO = _restaurantService.Create(restaurantCreateDTO);
            return Ok(restaurantResponseDTO);
        }

        [HttpPost("delete/{restaurantId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid restaurantId)
        {
            await _restaurantService.Delete(restaurantId);
            return Ok(_restaurantService.GetAll());
        }
    }
}
