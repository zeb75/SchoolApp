using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
        public class SchoolAppDbContext : DbContext
        {
            public SchoolAppDbContext() : base("name=SchoolAppDbContext")
            {
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Assignment> Assignments { get; set; }

        }
    
}
