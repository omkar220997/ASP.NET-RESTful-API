using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.DBContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)  
        {

        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Title = "Samsung",
                DisplayOrder = 1
            },
            new Category
            {
                Id = 2,
                Title = "Apple",
                DisplayOrder = 2
            },
            new Category
            {
                Id = 3,
                Title = "Motorola",
                DisplayOrder = 3
            },
            new Category
            {
                Id = 4,
                Title = "Nokia",
                DisplayOrder = 4
            },
            new Category
            {
                Id = 5,
                Title = "RealMe",
                DisplayOrder = 5
            }
            );
        }
    }
}
