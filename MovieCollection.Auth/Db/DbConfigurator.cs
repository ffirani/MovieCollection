using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace MovieCollection.Auth.Db
{
    public static class DbConfigurator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseInMemoryDatabase("AuthDb");

                // Register the entity sets needed by OpenIddict.
                options.UseOpenIddict();
                //options.UseSqlServer(configuration["ConnectionString"],
                //    sqlServerOptionsAction: sqlOptions =>
                //    {
                //        sqlOptions.MigrationsAssembly(typeof(DbConfigurator).GetTypeInfo().Assembly.GetName().Name);
                //        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                //    });
            },
            ServiceLifetime.Scoped);
            return services;
        }
    }
}
