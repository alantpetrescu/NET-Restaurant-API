using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Services.EmployeeService;

namespace NET_Restaurant_API.Helper.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<IDatabaseRepository<Ingredient>, IngredientRepository>();
			services.AddTransient<ManagerRepository>();
			services.AddTransient<RestaurantRepository>();

            return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
            services.AddTransient<ManagerService>();
			services.AddTransient<EmployeeService>();
			services.AddTransient<RestaurantService>();

			return services;
		}
	}
}