using Microsoft.EntityFrameworkCore;
using MovieCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieCollection.Infrastructure.Db.Seed
{
    public static class SeedDataExtensions
    {
        public static void CreateSeeds(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieRole>().HasData(
                new MovieRole { Id = new Guid("2E642C97-AF61-458E-81ED-86F8ADE9F61C"), Name = "Director" },
                new MovieRole { Id = new Guid("DCFE1FCE-7859-4DE0-8432-08AC615A45A8"), Name = "Actor"},
                new MovieRole { Id = new Guid("2C5BFC7B-34BE-4519-9E79-142D3AC7A5AA"), Name = "Actress"},
                new MovieRole { Id = new Guid("26C48D3B-C5F9-465C-ABA2-E98C105E95EF"), Name = "Writer" }
                ) ;
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = new Guid("953AC4A5-83E5-4193-BA2E-2E8F9E0B5C82"), Name = "Action" },
                new Genre { Id = new Guid("66B3D3B6-5F34-4DDD-A956-7131F23BA629"), Name = "Adventure" },
                new Genre { Id = new Guid("16B3F007-FFB8-422D-9FF7-87F4876EBA64"), Name = "Comedy" },
                new Genre { Id = new Guid("0FBBACD4-B09B-43F7-9B7A-32E9A715E3DB"), Name = "Drama" },
                new Genre { Id = new Guid("F493129B-DB9A-4584-AF4B-A1CE8369D027"), Name = "Horror" },
                new Genre { Id = new Guid("5C7AEEEB-C34A-4DC2-B337-24ECE8EB3FAD"), Name = "Science fiction" });

            modelBuilder.Entity<Person>().HasData(
                new Person {Id= new Guid("C507AABE-6D4B-41BE-A7C4-C9DBCAD7CAFE"), FirstName = "Tim", LastName="Robinson" },
                new Person { Id = new Guid("6CF82D0C-8765-480C-95DD-F32EDDE21B74"), FirstName = "Morgan", LastName = "Freeman" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = new Guid("1A84B59C-6D47-467F-9863-7BA645B45559"),
                    Title = "The Shawshank Redemption",
                    ReleaseData = new DateTime(1994, 6, 24),
                });

            modelBuilder.Entity<CastAndCrew>().HasData(
                new CastAndCrew()
                {
                    MovieId = new Guid("1A84B59C-6D47-467F-9863-7BA645B45559"),
                    PersonId = new Guid("C507AABE-6D4B-41BE-A7C4-C9DBCAD7CAFE"),
                    RoleId = new Guid("DCFE1FCE-7859-4DE0-8432-08AC615A45A8")
                },
                new CastAndCrew()
                {
                    MovieId = new Guid("1A84B59C-6D47-467F-9863-7BA645B45559"),
                    PersonId = new Guid("6CF82D0C-8765-480C-95DD-F32EDDE21B74"),
                    RoleId = new Guid("DCFE1FCE-7859-4DE0-8432-08AC615A45A8")
                });
        }
    }
}
