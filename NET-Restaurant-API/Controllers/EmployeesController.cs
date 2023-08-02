using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models;

namespace NET_Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]	
	public class EmployeesController : ControllerBase
	{
		public static List<Employee> employees = new List<Employee>
		{
			new Employee{ Id = 1, FirstName = "Employee1FirstName", LastName = "Employee1LastName", Age = 2 },
			new Employee{ Id = 2, FirstName = "Employee2FirstName", LastName = "Employee2LastName", Age = 18},
			new Employee{ Id = 3, FirstName = "Employee3FirstName", LastName = "Employee3LastName", Age = 5 },
			new Employee{ Id = 4, FirstName = "Employee4FirstName", LastName = "Employee4LastName", Age = 20 },
			new Employee{ Id = 5, FirstName = "Employee5FirstName", LastName = "Employee5LastName", Age = 16 }
		};

		// Endpoint
		// GET
		[HttpGet]
		public List<Employee> Get()
		{
			return employees;
		}

		[HttpGet("byId")]
		public Employee GetById(int id)
		{
			return employees.FirstOrDefault(x => x.Id.Equals(id));
		}

        [HttpGet("byId/{id}")]
        public Employee GetByIdInEndpoint(int id)
        {
            return employees.FirstOrDefault(x => x.Id.Equals(id));
        }

		[HttpGet("filter/{name}/{age}")]
		public List<Employee> GetWithFilters(string name, int age)
		{
			return employees.Where(s => (s.FirstName + " " + s.LastName).ToLower().Equals(name.ToLower()) && s.Age > age).ToList();
		}

		[HttpGet("fromRouteWithId/{id}")]
		public Employee GetByIdFromRoute([FromRoute] int id)
		{
            return employees.FirstOrDefault(x => x.Id.Equals(id));
        }

        [HttpGet("fromHeader")]
		public Employee GetByIdFromHeader([FromHeader] int id)
		{
            return employees.FirstOrDefault(x => x.Id.Equals(id));
        }

		[HttpGet("fromQuery")]
		public Employee GetByIdFromQuery([FromQuery] int id)
		{
            return employees.FirstOrDefault(x => x.Id.Equals(id));
        }

		// 200
        [HttpGet("StatusCodeOk")]
        public IActionResult StatusCodeOk()
        {
			return Ok("It's Ok!");
        }

        // 204
        [HttpGet("StatusCodeNoContent")]
        public IActionResult StatusCodeNoContent()
        {
			return NoContent();
        }

        // 404
        [HttpGet("StatusCodeNotFound")]
        public IActionResult StatusCodeNotFound()
        {
			return NotFound();
        }

        // 403
        [HttpGet("StatusCodeForbid")]
        public IActionResult StatusCodeForbid()
        {
			return Forbid();
        }

        // 400
        [HttpGet("StatusCodeBadRequest")]
        public IActionResult StatusCodeBadRequest()
        {
            return BadRequest();
        }

        // CREATE
        [HttpPost]
		public IActionResult Add(Employee employee)
		{
			try
			{
				employees.Add(employee);
                return Ok("The employee has been added with success!");
            } catch
			{
				return NotFound();
			}
        }
    }
}

