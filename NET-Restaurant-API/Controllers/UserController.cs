using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs.UserDTO;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUsers")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsers().Result);
        }

        [HttpGet("getUser/{userId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            return Ok(_userService.GetById(userId));
        }

        [HttpPost("update/{userId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid userId, UserAuthRequestDTO userAuthRequestDTO)
        {
            await _userService.Update(userId, userAuthRequestDTO);
            return Ok();
        }

        [HttpPost("delete/{userId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            await _userService.Delete(userId);
            return Ok(_userService.GetAllUsers());
        }
    }
}
