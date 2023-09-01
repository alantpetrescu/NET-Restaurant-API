using NET_Ingredient_API.Services;
using NET_Restaurant_API.Helpers.Jwt;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Services;

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
			services.AddTransient<RecipeRepository>();
			services.AddTransient<UserRepository>();
            services.AddTransient<IngredientRepository>();
            services.AddTransient<RecipeIngredientRepository>();

            return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
            services.AddTransient<ManagerService>();
			services.AddTransient<EmployeeService>();
			services.AddTransient<RestaurantService>();
            services.AddTransient<RecipeService>();
            services.AddTransient<UserService>();
            services.AddTransient<IngredientService>();
            services.AddTransient<RecipeIngredientService>();

            return services;
		}

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
			services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}