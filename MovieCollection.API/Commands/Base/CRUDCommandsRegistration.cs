using MediatR;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Query;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Base
{
    public static class CRUDCommandsRegistration
    {
        public static IServiceCollection AddCRUDCommands(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieDto>,CreateEntityResponse>, CreateEntityCommandHandler<MovieDto,Movie>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieDto>>, UpdateEntityCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieDto>>, DeleteEntityCommandHandler>();
            //services.AddTransient<IRequestHandler<RetrieveEntityQuery<MovieDto>>, RetrieveEntityQueryHandler>();
            //services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieDto>>, DeleteEntityCommandHandler>();
            return services;
        }
    }

}
