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
			new Employee{ Id = 1, FirstName = "Employee1FirstName", LastName = "Employee1LastName" },
			new Employee{ Id = 2, FirstName = "Employee2FirstName", LastName = "Employee2LastName" },
			new Employee{ Id = 3, FirstName = "Employee3FirstName", LastName = "Employee3LastName" },
			new Employee{ Id = 4, FirstName = "Employee4FirstName", LastName = "Employee4LastName" },
			new Employee{ Id = 5, FirstName = "Employee5FirstName", LastName = "Employee5LastName" }
		};

		// Endpoint
		[HttpGet]
		public List<Employee> Get()
		{
			return employees;
		}
	} 
}

