using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WaterPark.API.DbContexts;
using WaterPark.API.Models;
using System.Linq;


namespace WaterPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterRidesController : ControllerBase
    {
        private readonly WaterRideContext _context;

        public WaterRidesController(WaterRideContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<WaterRides> GetRides()
        {
            return _context.Rides;
        }
        [HttpGet("{id}")]
        public ActionResult<WaterRides> GetRides(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return (_context.Rides.FirstOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        public IActionResult PostRides([FromBody] WaterRides waterRides)
        {
            _context.Rides.Add(waterRides);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public ActionResult<WaterRides> PutRides(int id, [FromBody] WaterRides waterRides)
        {
            var RidesFromDb=_context.Rides.FirstOrDefault(x=>x.Id== id);
            if (RidesFromDb == null)
            {
                return NotFound();
            }
            RidesFromDb.RideCost=waterRides.RideCost;
            RidesFromDb.RideName=waterRides.RideName;
            RidesFromDb.RideAllowedTo=waterRides.RideAllowedTo;
            _context.Rides.Update(RidesFromDb);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpDelete("{id}")]
        public ActionResult<WaterRides> DeleteRide(int id)
        {
            var RidesFromDb=_context.Rides.FirstOrDefault(x=>x.Id== id);
            _context.Rides.Remove(RidesFromDb);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
