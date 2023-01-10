using Ecommerce.Api.DBContexts;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        private ApplicationContext _context;
        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable <Category> Get()
        {
            return _context.Categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id == 0)
            {
                //throw new ArgumentNullException("id");
                return NotFound();
            }
            else if (id > 6)
            {
                return BadRequest();
            }
            return Ok(_context.Categories.FirstOrDefault(x=>x.Id==id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var categoryfromDb = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryfromDb == null)
            {
                //throw new ArgumentNullException(nameof(categoryfromDb));
                return BadRequest();
            }

            categoryfromDb.Title= category.Title;
            categoryfromDb.DisplayOrder= category.DisplayOrder;
            _context.Categories.Update(categoryfromDb);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted); ;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var categoryFromDb = _context.Categories.Find(id);
            _context.Categories.Remove(categoryFromDb);
            _context.SaveChanges();

        }
    }
}
