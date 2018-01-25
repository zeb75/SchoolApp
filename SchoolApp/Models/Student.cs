using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Adress { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string City { get; set; }

        public List<Course> Courses { get; set; }
    }
}