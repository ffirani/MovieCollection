using Azure.Core;
using Azure;
using MediatR;

namespace MovieCollection.API.Security
{
    public static class SecurityBehaviorRegistration
    {
        public static IServiceCollection AddSecurityBehavior(this IServiceCollection services)
        {
            services.AddTransient<ISecurityManager, SecurityManager>();
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(SecurityBehavior<,>));
            return services;
        }
    }
}
