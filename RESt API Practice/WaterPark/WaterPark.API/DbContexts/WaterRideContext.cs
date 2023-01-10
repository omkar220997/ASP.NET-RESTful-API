using Microsoft.EntityFrameworkCore;
using WaterPark.API.Models;

namespace WaterPark.API.DbContexts
{
    public class WaterRideContext:DbContext
    {
        public WaterRideContext(DbContextOptions<WaterRideContext>options): base(options)
        {

        }
        public DbSet<WaterRides> Rides { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WaterRides>().HasData(
                new WaterRides
                {
                    Id = 1,
                    RideName = "Rain Dance",
                    RideCost = 100,
                    RideAllowedTo = "Everyone"
                },
                new WaterRides
                {
                    Id = 2,
                    RideName = "Dark Slide",
                    RideCost = 150,
                    RideAllowedTo = "Adult"
                },
                new WaterRides
                {
                    Id = 3,
                    RideName = "90Degree Slide",
                    RideCost = 250,
                    RideAllowedTo = "Adult"
                },
                new WaterRides
                {
                    Id = 4,
                    RideName = "Tube Way",
                    RideCost = 75,
                    RideAllowedTo = "Children"
                },
                new WaterRides
                {
                    Id = 5,
                    RideName = "Wave Pool",
                    RideCost = 150,
                    RideAllowedTo = "Children"
                }
                );
        }
    }
}
