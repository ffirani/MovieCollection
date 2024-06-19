using MediatR;
using MovieCollection.API.Commands.Dto;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace MovieCollection.API.Commands.Behavior
{
    public static class ValidationBehaviorRegistration
    {
        public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
