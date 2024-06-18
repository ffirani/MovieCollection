using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository.Base;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories
{
    public class MovieSelectionRepository : Repository<MovieSelection>
    {
        public MovieSelectionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
