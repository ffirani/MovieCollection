using Microsoft.AspNetCore.Identity;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Infrastructure.Repositories.Base;
using System.Security.Principal;

namespace MovieCollection.API.Core
{
    public static class ExecutionContextRegisterer
    {
        public static IServiceCollection AddExecutionContext(this IServiceCollection service)
        {
            service.AddTransient<IIdentityService, IdentityService>();
            service.AddScoped<IExecutionContext,ExecutionContext>();
            service.AddTransient<IRepositoryFactory, RepositoryFactory>();
            return service;
        }
    }
}
