using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets_API.DbContexts;
using MovieTickets_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private MovieContext _context;

        public TicketController(MovieContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<MovieDetails> GetMovie()
        {
            return _context.movieDetails;
        }
        [HttpGet("{id}")]
        public ActionResult<MovieDetails> GetMovie(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            return Ok(_context.movieDetails.FirstOrDefault(x=>x.Id==id));

        }
        [HttpPost]
        public ActionResult<MovieDetails> PostMovie([FromBody] MovieDetails movieDetails)
        {
            _context.movieDetails.Add(movieDetails);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public ActionResult<MovieDetails> PutMovie(int id, [FromBody] MovieDetails movieDetails)
        {
            var movieFromDb = _context.movieDetails.FirstOrDefault(x => x.Id == id);
            if(movieFromDb == null)
            {
                return BadRequest();
            }
            movieFromDb.MovieName = movieDetails.MovieName;
            movieFromDb.ScreenNumber= movieDetails.ScreenNumber;
            movieFromDb.ShowTime= movieDetails.ShowTime;
            movieFromDb.TicketPrice= movieDetails.TicketPrice;
            movieFromDb.MovieType= movieDetails.MovieType;
            _context.movieDetails.Update(movieFromDb);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpDelete("{id}")]
        public ActionResult<MovieDetails> DeleteMovie(int id)
        {
            if (id ==0 )
            {
                return NotFound();
            }
            var movieFromDb = _context.movieDetails.FirstOrDefault(x => x.Id == id);
            _context.movieDetails.Remove(movieFromDb);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
