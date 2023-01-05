using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CorseLibrary.API.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase   
    {
        private readonly ICourseLibraryRepository _courseLibraryrepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryrepository = courseLibraryRepository ??
                   throw new ArgumentNullException(nameof(courseLibraryRepository));
        }
        public IActionResult GetAuthors()
        {
             var authorsFromRepo = _courseLibraryrepository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }
    }
}
