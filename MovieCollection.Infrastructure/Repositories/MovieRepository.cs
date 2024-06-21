using Microsoft.EntityFrameworkCore;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async override Task<Movie> GetByIdAsync(Guid id)
        {
            return _dbSet
                .Include(m => m.Genres)
                .Include(m => m.CastAndCrews)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
