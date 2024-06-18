using MovieCollection.Domain.Models;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories
{
    internal class MovieRoleRepository : Repository<MovieRole>
    {
        public MovieRoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
