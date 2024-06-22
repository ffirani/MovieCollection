using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.Db.Base
{
    public interface IReadOnlyDbContext
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}
