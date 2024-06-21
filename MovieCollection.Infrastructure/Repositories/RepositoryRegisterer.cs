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
            services.AddTransient<IRepository<MovieSelection>, MovieSelectionRepository>();
            services.AddTransient<IRepository<MovieRole>, MovieRoleRepository>();
            services.AddTransient<IRepository<Genre>, GenreRepository>();
            return services;
        }
    }
}
