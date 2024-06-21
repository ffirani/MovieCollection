using Microsoft.EntityFrameworkCore;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Infrastructure.Db.Configurations;
using MovieCollection.Infrastructure.Db.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db
{
    public class AppDbContext : DbContext
    {
        private IIdentityService _identityService;

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSelection> MovieSelections { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CastAndCrew> CastAndCrews { get; set; }
        public DbSet<MovieSelectionMovie> MovieSelectionMovies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options, IIdentityService identityService) : base(options)
        {
            _identityService = identityService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore("UpdatedProperties");
            modelBuilder.Entity<Movie>().Ignore("UpdatedProperties");
            modelBuilder.Entity<MovieRole>().Ignore("UpdatedProperties");
            modelBuilder.Entity<Genre>().Ignore("UpdatedProperties");
            modelBuilder.Entity<Person>().Ignore("UpdatedProperties");
            modelBuilder.Entity<CastAndCrew>().Ignore("UpdatedProperties");
            modelBuilder.Entity<MovieSelection>().Ignore("UpdatedProperties");
            modelBuilder.Entity<MovieSelectionMovie>().Ignore("UpdatedProperties");

            modelBuilder.ApplyConfiguration(new MovieTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieSelectionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CastAndCrewTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieSelectionMovieTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.CreateSeeds();
        }
        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Entity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var now = DateTime.Now;
                var user = _identityService.GetUserIdentity();

                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedOn = now;
                    ((Entity)entry.Entity).CreatedBy = user;
                    ((Entity)entry.Entity).OwnerId = user;
                }

                ((Entity)entry.Entity).ModifiedOn = now;
                ((Entity)entry.Entity).ModifiedBy = user;
            }
        }

    }
}
