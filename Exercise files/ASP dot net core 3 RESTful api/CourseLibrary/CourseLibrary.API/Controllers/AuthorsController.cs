using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.ResourceParameters;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors([FromQuery] AuthorResourceParameters authorResourceParameters)
        {
            //throw new Exception("Test exception");
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorResourceParameters);
            //var authors = new List<AuthorDTO>();

            //foreach (var author in authorsFromRepo)
            //{
            //    authors.Add(new AuthorDTO()
            //    {
            //        Id = author.Id,
            //        Name = $"{author.FirstName} {author.LastName}",
            //        MainCategory = author.MainCategory,
            //        Age = author.DateOfBirth.GetCurrentAge()
            //    });
            //}
            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authorsFromRepo));
        }

        [HttpGet("{authorId}", Name= "GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDTO>(authorFromRepo));
        }
        [HttpPost]
        public ActionResult<AuthorDTO> CreateAuthor(AuthorForCreationDTO author)
        {
            var authorEntity = _mapper.Map<Entities.Author>(author);
            _courseLibraryRepository.AddAuthor(authorEntity);
            _courseLibraryRepository.Save();
            var authorToReturn = _mapper.Map<AuthorDTO>(authorEntity);
            return CreatedAtRoute("GetAuthor", new { authorId=authorToReturn.Id}, authorToReturn);
        }
    }
}
