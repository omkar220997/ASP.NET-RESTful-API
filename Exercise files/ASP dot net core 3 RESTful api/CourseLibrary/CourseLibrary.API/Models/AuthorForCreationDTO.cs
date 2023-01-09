﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseLibrary.API.Models
{
    public class AuthorForCreationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; }
        public ICollection<CourseForCreationDTO> Courses { get; set; }= new List<CourseForCreationDTO>();
    }
}
