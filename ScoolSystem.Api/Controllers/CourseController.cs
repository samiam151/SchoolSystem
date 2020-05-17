using System.Web.Http;
using System.Data.Entity;
using SchoolSystem.Data.Models;

namespace SchoolSystem.Api.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : EntityController<Course>
    {
        public CourseController(DbContext db) : base(db) { }
    }
}
