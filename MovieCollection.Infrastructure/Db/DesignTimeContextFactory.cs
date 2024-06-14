using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCollection.API.Core.Authentication;

namespace MovieCollection.Infrastructure.Db
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string connectionString = "Server=tcp:127.0.0.1,1433;Database=MovieCollectionDb;User Id=sa;Password=Passw0rd;TrustServerCertificate=true";
        AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
