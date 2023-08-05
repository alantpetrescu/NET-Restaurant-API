using NET_Restaurant_API.Models.DTOs;

namespace NET_Restaurant_API.Services.DemoService
{
    public interface IEmployeeService
    {
        EmployeeDTO GetDataMappedByEmail(string email);
    }
}
