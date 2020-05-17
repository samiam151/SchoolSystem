using SchoolSystem.Data;
using SchoolSystem.Data.Extentions;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SchoolSystem.Api.Controllers
{
    public class EntityController<T> : ApiController where T : Entity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public EntityController(DbContext context)
        {
            dbContext = context;
            dbSet = dbContext.ResolveDbSet(typeof(T)) as DbSet<T>;
        }

        [HttpGet]
        public IHttpActionResult GetEntityList()
        {
            var query = dbSet.AsQueryable();
            query = query.IncludeAll<T>(typeof(T));
            return Ok(query);
        }

        [HttpGet]
        public IHttpActionResult GetEntity(int id)
        {
            var query = dbSet.AsQueryable();
            T result = query.FirstOrDefault(e => e.Id == id);
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddEntity(T newEntity)
        {
            return Ok(newEntity);
        }
    }
}
