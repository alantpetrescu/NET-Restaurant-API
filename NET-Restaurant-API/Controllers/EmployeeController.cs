using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Services.DemoService;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetByEmail(string email)
        {
            var result = _employeeService.GetDataMappedByEmail(email);
            return Ok(result);
        }
    }
}
