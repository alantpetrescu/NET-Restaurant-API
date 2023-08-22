using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models;
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

        [HttpGet("getEmployee/id/{employeeId}")]
        public IActionResult GetEmployeeByEmail([FromRoute] Guid employeeId)
        {
            return Json(_employeeService.GetEmployeeById(employeeId));
        }

        [HttpGet("getEmployee/email/{employeeEmail}")]
        public IActionResult GetEmployeeById([FromRoute] String employeeEmail)
        {
            return Json(_employeeService.GetEmployeeByEmail(employeeEmail));
        }

        [HttpGet("getEmployees")]
        public IActionResult GetEmployees()
        {
            return Json(_employeeService.GetAll().Result);
        }

        [HttpPost("create")]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            Employee employee = _employeeService.Create(employeeDTO);
            return Ok(employee);
        }

        [HttpPost("delete/{employeeId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid employeeId)
        {
            await _employeeService.Delete(employeeId);
            return Ok(_employeeService.GetAll().Result);
        }

        //[HttpGet("byEmail/{email}")]
        //public IActionResult GetByEmail(string email)
        //{
        //    var result = _employeeService.GetDataMappedByEmail(email);
        //    return Ok(result);
        //}

        //[HttpPost("create")]
        //public IActionResult CreateEmployee(EmployeeDTO employee)
        //{
        //    _employeeService.Create(employee);
        //    return Ok();
        //}
    }
}
