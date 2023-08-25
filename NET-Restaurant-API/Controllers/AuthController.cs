using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models.DTOs.UserDTO;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserAuthRequestDTO user)
        {
            await _userService.Create(user);
            return Ok();
        }

        [HttpPost("loginUser")]
        public IActionResult LoginUser(UserAuthRequestDTO user)
        {
            var response = _userService.Authentificate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
    }
}
