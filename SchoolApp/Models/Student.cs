﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public List<Course> Courses { get; set; }
    }
}