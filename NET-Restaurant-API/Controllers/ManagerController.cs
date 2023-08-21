using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Models;
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

        [HttpGet("getManagers")]
        public IActionResult GetManagers()
        {
            return Json(_managerService.GetAll().Result);
        }


        [HttpPost("create")]
        public IActionResult Create(ManagerDTO managerDTO)
        {
            Manager manager = _managerService.Create(managerDTO);
            return Ok(manager);
        }
    }
}
