using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
    [Route("api/authors/{authorId}/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>>GetCoursesForAuthor(Guid authorId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var coursesForAuthorFromRepo = _courseLibraryRepository.GetCourses(authorId);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesForAuthorFromRepo));
        }
        [HttpGet("{courseId}", Name ="GetCourse")]
        public ActionResult<IEnumerable<CourseDto>> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var courseForAuthorfromRepo= _courseLibraryRepository.GetCourse(authorId, courseId);
            if(courseForAuthorfromRepo == null)
            {
                return NotFound();  
            }
            return Ok(_mapper.Map<CourseDto>(courseForAuthorfromRepo)); 
        }
        [HttpPost]
        public ActionResult<CourseDto> CreateCourseForAuthor(Guid authorId, CourseForCreationDto course )
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
             var courseEntity=_mapper.Map<Entities.Course>(course);
            _courseLibraryRepository.AddCourse(authorId,courseEntity);
            _courseLibraryRepository.Save();

            var courseToReturn=_mapper.Map<CourseDto>(courseEntity);
            return CreatedAtRoute("GetCourse", new { authorId=authorId, courseId = courseToReturn.Id }, courseToReturn);
        }
    }
}
