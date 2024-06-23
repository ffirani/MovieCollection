using MediatR;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Query;
using MovieCollection.Domain.Models;
using MovieCollection.Query.View;

namespace MovieCollection.API.Commands.Base
{
    public static class CommandsRegistration
    {
        public static IServiceCollection AddCRUDCommands(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieDto>,CreateEntityResponse>, CreateEntityCommandHandler<MovieDto,Movie>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieDto>>, UpdateEntityCommandHandler<MovieDto, Movie>>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieDto>>, DeleteEntityCommandHandler<MovieDto, Movie>>();
            
            

            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieSelectionDto>, CreateEntityResponse>, CreateEntityCommandHandler<MovieSelectionDto, MovieSelection>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieSelectionDto>>, UpdateEntityCommandHandler<MovieSelectionDto, MovieSelection>>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieSelectionDto>>, DeleteEntityCommandHandler<MovieSelectionDto, MovieSelection>>();
            services.AddTransient<IRequestHandler<RetrieveEntityQuery<MovieSelectionView>, RetrieveEntityResponse<MovieSelectionView>>, RetrieveEntityQueryHandler<MovieSelectionView>>();
            services.AddTransient<IRequestHandler<AssociateToSelectionCommand>, AssociateToSelectionCommandHandler>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieRoleDto>, CreateEntityResponse>, CreateEntityCommandHandler<MovieRoleDto, MovieRole>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<MovieRoleDto>>, UpdateEntityCommandHandler<MovieRoleDto, MovieRole>>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<MovieRoleDto>>, DeleteEntityCommandHandler<MovieRoleDto, MovieRole>>();
            services.AddTransient<IRequestHandler<RetrieveEntityQuery<MovieRoleView>, RetrieveEntityResponse<MovieRoleView>>, RetrieveEntityQueryHandler<MovieRoleView>>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<PersonDto>, CreateEntityResponse>, CreateEntityCommandHandler<PersonDto, Person>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<PersonDto>>, UpdateEntityCommandHandler<PersonDto, Person>>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<PersonDto>>, DeleteEntityCommandHandler<PersonDto, Person>>();
            services.AddTransient<IRequestHandler<RetrieveEntityQuery<PersonView>, RetrieveEntityResponse<PersonView>>, RetrieveEntityQueryHandler<PersonView>>();

            return services;
        }
    }

}
