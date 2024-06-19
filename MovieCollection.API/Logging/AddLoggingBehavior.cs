using MediatR;
using System.Runtime.CompilerServices;

namespace MovieCollection.API.Logging
{
    public static class AddLoggingBehavior
    {
        public static IServiceCollection AddLogBehavior(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPipelineBehavior<,>),typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
