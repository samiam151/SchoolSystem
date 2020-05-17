using System.Data.Entity;

namespace SchoolSystem.Data.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .HasMany
        //}
    }
}
