using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Data.Models
{
    public class Program : Entity
    {
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
