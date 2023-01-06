﻿using System.ComponentModel.DataAnnotations;
using System;

namespace CourseLibrary.API.Models
{
    public class AuthorDTO
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string MainCategory { get; set; }
    }
}
