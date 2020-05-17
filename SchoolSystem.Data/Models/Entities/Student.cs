using System;
using System.Collections.Generic;

namespace SchoolSystem.Data.Models
{
    public class Student : Entity
    {
        public Student()
        {
            Courses = new List<Course>();
        }

        public string Name { get; set;  }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
