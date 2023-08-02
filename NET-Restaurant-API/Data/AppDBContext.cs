using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Models;

namespace NET_Restaurant_API.Data
{
	public class AppDBContext : DbContext
	{
        public AppDBContext() : base()
        {
        }
        protected override void OnConfiguring
     (DbContextOptionsBuilder options)
        {
            var connectionString =
"server=localhost;database=restaurantdb;uid=alex;password=12345678";
            var serverVersion = new MySqlServerVersion(new
Version(8, 0, 33));
            options.UseMySql(connectionString, serverVersion);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

