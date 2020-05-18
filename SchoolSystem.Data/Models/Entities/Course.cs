using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Data.Models
{
    public class Course : Entity
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [MinLength(2)][MaxLength(50)]
        public string Name { get; set; }

        public int ProgramId { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
