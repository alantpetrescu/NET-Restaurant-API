using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getEmployee/id/{employeeId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetEmployeeByEmail([FromRoute] Guid employeeId)
        {
            return Ok(_employeeService.GetEmployeeById(employeeId));
        }

        [HttpGet("getEmployee/email/{employeeEmail}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetEmployeeById([FromRoute] String employeeEmail)
        {
            return Ok(_employeeService.GetEmployeeByEmail(employeeEmail));
        }

        [HttpGet("getEmployees")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetAll().Result);
        }

        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(EmployeeCreateDTO employeeCreateDTO)
        {
            EmployeeResponseDTO employeeResponseDTO = _employeeService.Create(employeeCreateDTO);
            return Ok(employeeResponseDTO);
        }

        [HttpPost("update/{employeeId}")]
        [Authorization(Role.Admin)]
        public IActionResult Update([FromRoute] Guid employeeId, EmployeeCreateDTO employeeCreateDTO)
        {
            EmployeeResponseDTO employeeResponseDTO = _employeeService.Update(employeeId, employeeCreateDTO);
            return Ok(employeeResponseDTO);
        }

        [HttpPost("delete/{employeeId}")]
        [Authorization(Role.Admin)]
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
