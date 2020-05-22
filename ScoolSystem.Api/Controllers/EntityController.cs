using SchoolSystem.Data;
using SchoolSystem.Data.Extentions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public IHttpActionResult GetAllEntities()
        {
            var query = dbSet.AsQueryable();
            var result = query.IncludeAll<T>(typeof(T));
            return Ok(result.ToList());
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
        public async Task<IHttpActionResult> AddEntity(T newEntity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                dbSet.Add(newEntity);
                var result = await dbContext.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = newEntity?.Id }, newEntity);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateEntity(T entity)
        {
            try
            {
                var e = await dbSet.FindAsync(entity.Id);
                if (e == null)
                {
                    return NotFound();
                }
                dbContext.UpdateEntity<T>(entity);
                await dbContext.SaveChangesAsync();
                return Ok(entity);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteEntity(int id)
        {
            try
            {
                var e = await dbSet.FindAsync(id);
                if (e == null)
                {
                    return NotFound();
                }
                dbSet.Remove(e);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
