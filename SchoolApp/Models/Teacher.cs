using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Course> Courses { get; set; }

    }
}