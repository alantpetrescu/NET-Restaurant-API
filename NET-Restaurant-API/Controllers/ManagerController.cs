using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Services.EmployeeService;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("getManager/{managerId}")]
        public IActionResult GetManager([FromRoute] Guid managerId)
        {
            return Json(_managerService.GetManager(managerId));
        }

        [HttpGet("getManagers")]
        public IActionResult GetManagers()
        {
            return Json(_managerService.GetAll().Result);
        }


        [HttpPost("create")]
        public IActionResult Create(ManagerCreateDTO managerCreateDTO)
        {
            ManagerResponseDTO managerResponseDTO = _managerService.Create(managerCreateDTO);
            return Ok(managerResponseDTO);
        }

        [HttpPost("delete/{managerId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid managerId)
        {
            await _managerService.Delete(managerId);
            return Ok(_managerService.GetAll().Result);
        }
    }
}
