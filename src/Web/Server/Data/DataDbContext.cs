using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Data.Entities;

namespace QRCodeMenu.Server.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Affiliate> Affiliate { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<DishesGroup> DishesGroups { get; set; } = null!;
    }
}
