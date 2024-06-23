using MediatR;
using MovieCollection.Query.Parser;
using MovieCollection.Query.View;

namespace MovieCollection.API.Query
{
    public static class QueryRegisterer
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient(typeof(IQueryParser<>),typeof(QueryParser<>));

            services.AddTransient<IRequestHandler<RetrieveEntityQuery<MovieView>, RetrieveEntityResponse<MovieView>>, RetrieveEntityQueryHandler<MovieView>>();
            services.AddTransient<IRequestHandler<RetrieveMultipleEntityQuery<MovieView>, RetrieveMultipleEntityResponse<MovieView>>, RetrieveMultipleEntityQueryHandler<MovieView>>();

            return services;
        }
    }
}
