using System;

namespace MovieTickets_API.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int ScreenNumber { get; set; }
        public DateTime ShowTime { get; set; }
        public string MovieType { get; set; }
        public double TicketPrice { get; set; }
    }
}
