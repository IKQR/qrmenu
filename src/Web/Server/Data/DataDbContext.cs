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

        DbSet<Restaurant> Restaurants { get; set; } = null!;
        DbSet<Affiliate> Affiliate { get; set; } = null!;

        DbSet<Dish> Dishes { get; set; } = null!;
        DbSet<Ingredient> Ingredients { get; set; } = null!;
    }
}
