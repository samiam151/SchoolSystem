using SchoolSystem.Data.Models;
using System.Data.Entity;
using System.Web.Http;

namespace SchoolSystem.Api.Controllers
{
    public class StudentsController : EntityController<Student>
    {
        public StudentsController(DbContext context) : base(context) { }
    }
}
