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
            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieDto>,CreateEntityResponse>, CreateEntityCommandHandler<MovieDto,MovieSelection>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieDto>>, UpdateEntityCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieDto>>, DeleteEntityCommandHandler>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieSelectionDto>, CreateEntityResponse>, CreateEntityCommandHandler<MovieSelectionDto, MovieSelection>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieSelectionDto>>, UpdateEntityCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieSelectionDto>>, DeleteEntityCommandHandler>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieRoleDto>, CreateEntityResponse>, CreateEntityCommandHandler<MovieRoleDto, MovieRole>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieRoleDto>>, UpdateEntityCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieRoleDto>>, DeleteEntityCommandHandler>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<PersonDto>, CreateEntityResponse>, CreateEntityCommandHandler<PersonDto, Person>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<PersonDto>>, UpdateEntityCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<PersonDto>>, DeleteEntityCommandHandler>();
            //services.AddTransient<IRequestHandler<RetrieveEntityQuery<MovieDto>>, RetrieveEntityQueryHandler>();
            //services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieDto>>, DeleteEntityCommandHandler>();
            return services;
        }
    }

}
