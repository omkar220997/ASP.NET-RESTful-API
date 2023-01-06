using CourseLibrary.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CourseLibrary.API.Models
{
    public class CourseDTO 
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

       public Guid AuthorId { get; set; }
    }
}
