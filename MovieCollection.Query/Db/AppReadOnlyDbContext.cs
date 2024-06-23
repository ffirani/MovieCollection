using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MovieCollection.Query.Db.Base;
using MovieCollection.Query.View;
using MovieCollection.Query.Db.Configurations.Type;

namespace MovieCollection.Query.Db
{
    public class AppReadOnlyDbContext: DbContext, IReadOnlyDbContext
    {
        public DbSet<UserView> Users { get; set; }
        public DbSet<MovieView> Movies { get; set; }
        public DbSet<MovieSelectionView> MovieSelections { get; set; }
        public DbSet<MovieRoleView> MovieRoles { get; set; }
        public DbSet<GenreView> Genres { get; set; }
        public DbSet<PersonView> Persons { get; set; }
        public DbSet<CastAndCrewView> CastAndCrews { get; set; }
        public DbSet<MovieSelectionMovieView> MovieSelectionMovies { get; set; }

        public AppReadOnlyDbContext(DbContextOptions<AppReadOnlyDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieSelectionViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CastAndCrewViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieRoleViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieSelectionMovieViewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserViewTypeConfiguration());
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking();
        }

        // Override SaveChanges to throw an exception
        public override int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

    }
}
