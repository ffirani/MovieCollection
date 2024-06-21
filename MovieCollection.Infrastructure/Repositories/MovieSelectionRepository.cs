using Microsoft.EntityFrameworkCore;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;
using MovieCollection.Domain.Repository.Base;
using MovieCollection.Infrastructure.Db;
using MovieCollection.Infrastructure.Db.Exception;
using MovieCollection.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories
{
    public class MovieSelectionRepository : Repository<MovieSelection>,IMovieSelectionRepository
    {
        public MovieSelectionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AssociateMovieAsync(Guid selectionId, Guid movieId)
        {
            try
            {
                var movieSelectionMovie = new MovieSelectionMovie() { MovieId = movieId, MovieSelectionId = selectionId };
                _dbContext.MovieSelectionMovies.Add(movieSelectionMovie);
                await _dbContext.SaveChangesAsync();
            }
            catch(DatabaseException ex)
            {
                throw;
            }
            catch(Exception ex) 
            {
                throw new DatabaseException("ERR4011", "Unexpected error in db operation", ex);
            }
            
        }

        public async Task DisassociateMovieAsync(Guid selectionId, Guid movieId)
        {
            try
            {
                var movieSelectionMovie = _dbContext.MovieSelectionMovies
                                                    .Single(msm=>msm.MovieId == movieId && 
                                                            msm.MovieSelectionId == selectionId );
                _dbContext.MovieSelectionMovies.Remove(movieSelectionMovie);
                await _dbContext.SaveChangesAsync();
            }
            catch (DatabaseException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("ERR4012", "Unexpected error in db operation", ex);
            }
        }
    }
}
