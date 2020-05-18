using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SchoolSystem.Data.Models
{
    public class Student : Entity
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        [MinLength(2)][MaxLength(50)]
        public string Name { get; set;  }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
