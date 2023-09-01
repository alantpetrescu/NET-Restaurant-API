using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("getManager/{managerId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetManager([FromRoute] Guid managerId)
        {
            return Ok(_managerService.GetManager(managerId));
        }

        [HttpGet("getManagers")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetManagers()
        {
            return Ok(_managerService.GetAll().Result);
        }


        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(ManagerCreateDTO managerCreateDTO)
        {
            ManagerResponseDTO managerResponseDTO = _managerService.Create(managerCreateDTO);
            return Ok(managerResponseDTO);
        }

        [HttpPost("update/{managerId}")]
        [Authorization(Role.Admin)]
        public IActionResult Update([FromRoute] Guid managerId, ManagerCreateDTO managerCreateDTO)
        {
            ManagerResponseDTO managerResponseDTO = _managerService.Update(managerId, managerCreateDTO);
            return Ok(managerResponseDTO);
        }

        [HttpPost("delete/{managerId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid managerId)
        {
            await _managerService.Delete(managerId);
            return Ok(_managerService.GetAll().Result);
        }
    }
}
