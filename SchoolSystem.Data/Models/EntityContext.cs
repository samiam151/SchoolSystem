using System.Data.Entity;

namespace SchoolSystem.Data.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(c => c.Courses)
                .WithMany(c => c.Students)
                .Map(cs => {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("StudentCourse");
                });
        }
    }
}
