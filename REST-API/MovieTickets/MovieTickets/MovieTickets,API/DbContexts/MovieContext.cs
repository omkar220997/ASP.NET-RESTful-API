using Microsoft.EntityFrameworkCore;
using MovieTickets_API.Models;
using System;

namespace MovieTickets_API.DbContexts
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext>options):base(options)
        {

        }
        public DbSet<MovieDetails> movieDetails { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<MovieDetails>().HasData(
              new MovieDetails
              {
                  Id = 1001,
                  MovieName = "Bhediya",
                  ScreenNumber = 2,
                  ShowTime = new DateTime(2023, 1, 10, 8, 30, 00),
                  MovieType = "3D",
                  TicketPrice = 350
              },
              new MovieDetails
              {
                  Id = 1002,
                  MovieName = "Avatar: The Way of Water",
                  ScreenNumber = 3,
                  ShowTime = new DateTime(2023, 1, 10, 10, 45, 00),
                  MovieType = "4D",
                  TicketPrice = 480
              },
              new MovieDetails
              {

                  Id = 1003,
                  MovieName = "Ved",
                  ScreenNumber = 1,
                  ShowTime = new DateTime(2023, 1, 10, 9, 00, 00),
                  MovieType = "3D",
                  TicketPrice = 275
              },
              new MovieDetails
              {
                  Id = 1004,
                  MovieName = "Cirkus",
                  ScreenNumber = 3,
                  ShowTime = new DateTime(2023, 1, 10, 2, 30, 00),
                  MovieType = "2D",
                  TicketPrice = 300
              },
              new MovieDetails
              {
                  Id = 1005,
                  MovieName = "Drishyam 2",
                  ScreenNumber = 1,
                  ShowTime = new DateTime(2023, 1, 10, 1, 30, 00),
                  MovieType = "2D",
                  TicketPrice = 350
              },
              new MovieDetails
              {
                  Id = 1006,
                  MovieName = "Vikram",
                  ScreenNumber = 2,
                  ShowTime = new DateTime(2023, 1, 10, 3, 30, 00),
                  MovieType = "2D",
                  TicketPrice = 400
              }
              );
         }
    }
}
