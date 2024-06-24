using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Infrastructure.Db;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.API.Test.Integration.Db
{
    public class DatabaseFixture : IDisposable
    {
        public AppDbContext Db { get; set; }
        public DatabaseFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(configuration["ConnectionString"])
                .Options;

            var identityFake = Substitute.For<IIdentityService>();
            identityFake.GetUserIdentity().Returns(new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC"));
            Db = new AppDbContext(options, identityFake);
            Db.Database.EnsureCreated();
            CleanDatabase();
        }

        public void CleanDatabase()
        {
            try
            {
                Db.Movies.RemoveRange(Db.Movies);
                Db.MovieSelections.RemoveRange(Db.MovieSelections);
                Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

            }
        }

        public void Dispose()
        {
            CleanDatabase();
            Db.Dispose();
        }
    }
}
