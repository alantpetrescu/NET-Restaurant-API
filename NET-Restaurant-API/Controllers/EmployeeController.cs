using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Services.EmployeeService;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getEmployees")]
        public IActionResult GetManagers()
        {
            return Json(_employeeService.GetAll().Result);
        }

        [HttpGet("byEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _employeeService.GetDataMappedByEmail(email);
            return Ok(result);
        }

        //[HttpPost("create")]
        //public IActionResult CreateEmployee(EmployeeDTO employee)
        //{
        //    _employeeService.Create(employee);
        //    return Ok();
        //}
    }
}
