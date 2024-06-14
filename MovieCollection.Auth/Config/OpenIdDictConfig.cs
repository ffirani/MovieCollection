using Microsoft.EntityFrameworkCore;
using MovieCollection.Auth.Db;

namespace MovieCollection.Auth.Config
{
    public static class OpenIdDictConfig
    {
        public static IServiceCollection AddOpenIdDict(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the EF Core stores/models.
                    options.UseEntityFrameworkCore()
                        .UseDbContext<AuthDbContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    options
                        .AllowClientCredentialsFlow()
                        .AllowAuthorizationCodeFlow().RequireProofKeyForCodeExchange();
                    options
                        .SetTokenEndpointUris("/connect/token")
                        .SetAuthorizationEndpointUris("/connect/authorize")
                        .SetTokenEndpointUris("/connect/token");

                    // Encryption and signing of tokens
                    options
                        .AddEphemeralEncryptionKey()
                        .AddEphemeralSigningKey()
                        .DisableAccessTokenEncryption();

                    // Register scopes (permissions)
                    options.RegisterScopes("api");

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options
                        .UseAspNetCore()
                        .EnableTokenEndpointPassthrough()
                        .EnableAuthorizationEndpointPassthrough();
                });
            services.AddHostedService<SeedDataWorker>();
            return services;
        }
    }
}
