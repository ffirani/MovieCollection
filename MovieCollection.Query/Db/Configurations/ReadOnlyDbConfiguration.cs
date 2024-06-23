using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieCollection.Query.Db.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.Db.Configurations
{
    public static class ReadOnlyDbConfigurator
    {
        public static IServiceCollection AddReadOnlyDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IReadOnlyDbContext, AppReadOnlyDbContext>();
            services.AddDbContext<AppReadOnlyDbContext>(options =>
            {
#if DEBUG
                options.UseInMemoryDatabase("MovieCollection");
            }
#else
                options.UseSqlServer(configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            }
#endif
            , ServiceLifetime.Scoped);
            return services;
        }
    }
}
