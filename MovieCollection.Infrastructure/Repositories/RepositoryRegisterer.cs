using Microsoft.Extensions.DependencyInjection;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository.Base;

namespace MovieCollection.Infrastructure.Repositories
{
    public static class RepositoryRegisterer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            return services;
        }
    }
}
