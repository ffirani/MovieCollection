using MediatR;
using MovieCollection.API.Dto;
using MovieCollection.Domain.Models;

namespace MovieCollection.API.Commands.Base
{
    public static class CRUDCommandsRegistration
    {
        public static IServiceCollection AddCRUDCommands(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateEntityCommand<MovieDto>,CreateEntityResponse>, CreateEntityCommandHandler>();
            return services;
        }
    }

}
