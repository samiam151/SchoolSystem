using System.Web.Http;
using System.Data.Entity;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Api.Controllers
{
    public class CoursesController : EntityController<Course>
    {
        public CoursesController(DbContext db) : base(db) { }
    }
}
