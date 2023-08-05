using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Services.DemoService;
using NET_Restaurant_API.Services.EmployeeService;

namespace NET_Restaurant_API.Helper.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IDatabaseRepository<Employee>, EmployeeRepository>();
			services.AddTransient<IDatabaseRepository<Ingredient>, IngredientRepository>();

            return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddTransient<IEmployeeService, EmployeeService>();

			return services;
		}
	}
}