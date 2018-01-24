using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Course AssignedTo { get; set; }
    }
}