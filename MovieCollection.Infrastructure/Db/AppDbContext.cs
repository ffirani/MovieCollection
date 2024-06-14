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
        public DbSet<Movie> Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options, IIdentityService identityService) : base(options)
        {
            _identityService = identityService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());
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
                var now = DateTime.UtcNow;
                var user = _identityService.GetUserIdentity();

                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedOn = now;
                    ((Entity)entry.Entity).CreatedBy = user;
                }

                ((Entity)entry.Entity).ModifiedOn = now;
                ((Entity)entry.Entity).ModifiedBy = user;
            }
        }

    }
}
