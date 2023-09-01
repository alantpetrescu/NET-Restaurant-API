using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("getRestaurants")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRestaurants()
        {
            return Ok(_restaurantService.GetAll());
        }

        [HttpGet("getRestaurant/{restaurantId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRestaurant([FromRoute] Guid restaurantId)
        {
            return Ok(_restaurantService.GetRestaurant(restaurantId));
        }


        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(RestaurantCreateDTO restaurantCreateDTO)
        {
            RestaurantResponseDTO restaurantResponseDTO = _restaurantService.Create(restaurantCreateDTO);
            return Ok(restaurantResponseDTO);
        }

        [HttpPost("update/{restaurantId}")]
        [Authorization(Role.Admin)]
        public IActionResult Update([FromRoute] Guid restaurantId, RestaurantCreateDTO restaurantCreateDTO)
        {
            RestaurantResponseDTO restaurantResponseDTOAfter = _restaurantService.Update(restaurantId, restaurantCreateDTO);
            return Ok(restaurantResponseDTOAfter);
        }

        [HttpPost("delete/{restaurantId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid restaurantId)
        {
            await _restaurantService.Delete(restaurantId);
            return Ok(_restaurantService.GetAll());
        }
    }
}
