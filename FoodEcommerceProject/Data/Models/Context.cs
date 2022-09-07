using Microsoft.EntityFrameworkCore;

namespace FoodEcommerceProject.Data.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CJ5M07K\\SQLEXPRESS;Database=FoodEcommerceDB; integrated security=True;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
