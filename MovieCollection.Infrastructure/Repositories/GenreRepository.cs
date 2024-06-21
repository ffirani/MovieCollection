using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
