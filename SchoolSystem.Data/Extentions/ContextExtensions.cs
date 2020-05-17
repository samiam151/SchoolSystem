using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SchoolSystem.Data.Extentions
{
    public static class ContextExtensions
    {
        public static object ResolveDbSet(this DbContext source, Type type)
        {
            var dbSetType = typeof(DbSet<>).MakeGenericType(type);
            foreach (var method in source.GetType().GetMethods())
                if (method.ReturnType.IsAssignableFrom(dbSetType))
                    return method.Invoke(source, null);
            throw new NotImplementedException("Unable to find DbSet for type: " + dbSetType);
        }

        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> source, Type type)
        {
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.Name.Contains("ICollection"))
                {
                    source.Include(prop.Name);
                }
            }
            return source;
        }

        public static void UpdateEntity<T>(this DbContext context, T updatedEntity) where T : Entity
        {
            DbSet<T> matchedSet = context.ResolveDbSet(typeof(T)) as DbSet<T>;
            context.Entry(matchedSet).CurrentValues.SetValues(updatedEntity);
        }
    }
}
