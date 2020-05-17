using System;
using System.Data.Entity.Migrations;
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
            context.Students.AddOrUpdate(
                x => x.Id,
                new Student() { Name = "Nick", DateOfBirth = new DateTime(1988, 5, 3) },
                new Student() { Name = "Khea", DateOfBirth = new DateTime(1989, 7, 4) },
                new Student() { Name = "Chelsea", DateOfBirth = new DateTime(1990, 2, 23) },
                new Student() { Name = "Zach", DateOfBirth = new DateTime(1985, 4, 30) }
            );

            context.Courses.AddOrUpdate(
                x => x.Id, 
                new Course() { Name = "Calculus" },
                new Course() { Name = "Computer Architecture" },
                new Course() { Name = "Physics" },
                new Course() { Name = "English" }
            );

            foreach (Student student in context.Students)
            {
                var course = context.Courses.Find(student.Id);
                student.Courses.Add(course);
            }
        }
    }
}
