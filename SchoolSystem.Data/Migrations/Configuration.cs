using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Xml;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Data.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.Models.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityContext context)
        {
            
            List<Student> students = new List<Student>
            {
                new Student() { Name = "Nick", DateOfBirth = new DateTime(1988, 5, 3) },
                new Student() { Name = "Khea", DateOfBirth = new DateTime(1989, 7, 4) },
                new Student() { Name = "Chelsea", DateOfBirth = new DateTime(1990, 2, 23) },
                new Student() { Name = "Zach", DateOfBirth = new DateTime(1985, 4, 30) }
            };

            List<Course> courses = new List<Course> {
                new Course() { Name = "Calculus" },
                new Course() { Name = "Computer Architecture" },
                new Course() { Name = "Physics" },
                new Course() { Name = "English" }
            };

            Program program = new Program() { Name = "Computer Science" };

            // Relate data
            foreach(Student student in students)
            {
                int index = students.IndexOf(student);
                int nextIndex = (index + 1) == students.Count ? 0 : index++;
                var addCourses = new List<Course> { courses[index], courses[nextIndex] };

                foreach (var course in addCourses)
                {
                    student.Courses.Add(course);
                }
            }


            // Add Students
            context.Students.AddRange(students);

            // Add Courses
            context.Courses.AddRange(courses);

            // Add a Program
            context.Programs.Add(program);

        }
    }
}
