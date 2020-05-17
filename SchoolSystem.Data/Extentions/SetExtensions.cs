using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Extentions
{
    public static class SetExtensions
    {
        public static IEnumerable<T> FindBy<T>(this DbSet<T> set, Expression<Func<T, bool>> predicate) where T : Entity
        {
            IEnumerable<T> results = set.Where(predicate).ToList();
            return results;
        }

        
    }
}
