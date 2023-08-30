using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Models;

namespace NET_Restaurant_API.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; } 

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Manager>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Restaurant>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Ingredient>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Recipe>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<User>()
            //    .Property(e => e.DateCreated)
            //    .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Manager)
                .WithOne(m => m.Restaurant)
                .HasForeignKey<Manager>(r => r.RestaurantId)
                .IsRequired();

            modelBuilder.Entity<RestaurantRecipe>()
                .HasKey(rr => new { rr.RestaurantId, rr.RecipeId });

            modelBuilder.Entity<RestaurantRecipe>()
                .HasOne(rr => rr.Restaurant)
                .WithMany(r => r.RestaurantRecipes)
                .HasForeignKey(rr => rr.RestaurantId);

            modelBuilder.Entity<RestaurantRecipe>()
                .HasOne(rr => rr.Recipe)
                .WithMany(r => r.RestaurantRecipes)
                .HasForeignKey(rr => rr.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.UseGuidCollation(string.Empty);
            base.OnModelCreating(modelBuilder);
        }
    }
}

