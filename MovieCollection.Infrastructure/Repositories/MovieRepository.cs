using Microsoft.EntityFrameworkCore;
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
    public class MovieRepository : Repository<Movie>,IMovieRepository
    {
        public MovieRepository(AppDbContext dbContext):base(dbContext) { }

        public async override Task<Guid> CreateAsync(Movie entity)
        {
            _dbContext.Genres.AttachRange(entity.Genres);
            _dbContext.CastAndCrews.AttachRange(entity.CastAndCrews);
            return await base.CreateAsync(entity);
        }

    }
}
