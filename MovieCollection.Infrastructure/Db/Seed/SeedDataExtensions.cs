using Microsoft.EntityFrameworkCore;
using MovieCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Seed
{
    public static class SeedDataExtensions
    {
        public static void CreateSeeds(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Shawshank Redemption",
                    ReleaseData = new DateTime(1994, 6, 24),
                    CreatedBy = Guid.Parse("A3B40D6B-8BCF-4969-A000-659062F888C2"),
                    CreatedOn = new DateTime(2024, 6, 11),
                    ModifiedBy = Guid.Parse("A3B40D6B-8BCF-4969-A000-659062F888C2"),
                    ModifiedOn = new DateTime(2024, 6, 11)
                });
        }
    }
}
