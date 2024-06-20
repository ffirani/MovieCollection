using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Infrastructure.Db.Configurations;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Infrastructure.Db;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using MovieCollection.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MovieCollection.API.Logging;
using MovieCollection.API.Commands.Behavior;
using static System.Net.Mime.MediaTypeNames;
using FluentValidation;
using MovieCollection.API.Error;
using MovieCollection.API.Security;

namespace MovieCollection.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();
            try
            {
                //Log.Information("Starting web application");

                var builder = WebApplication.CreateBuilder(args);
                builder.Logging.ClearProviders();

                builder.Host.UseSerilog(CreateSerilogLogger(builder.Configuration));
                builder.Services.AddSerilog(lc => lc
                                            .WriteTo.Console()
                                            .ReadFrom.Configuration(builder.Configuration));

                builder.Services.AddHttpContextAccessor();
                // Load JWT settings from configuration
                var jwtSettings = new JwtSettings();
                builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
                builder.Services.AddSingleton(jwtSettings);

                // Configure authentication
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                    options.MapInboundClaims = true;
                });

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Movie Collection API",
                        Version = "v1"
                    });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                        new string[] {}
                    }
                    });
                });


                builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
                builder.Services.AddLogBehavior();
                builder.Services.AddSecurityBehavior();
                builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
                builder.Services.AddValidationBehavior();
                builder.Services.AddCRUDCommands();
                builder.Services.AddExecutionContext();

                builder.Services.AddDatabase(builder.Configuration);
                builder.Services.AddRepository();
                builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program)));
                builder.Services.AddHealthChecks();
                builder.Services.AddTransient<GlobalExceptionHandler>();

                var app = builder.Build();

                app.UseMiddleware<GlobalExceptionHandler>();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                else
                {
                    app.UseHsts();
                }
                await InitializeDb(app);

                app.MapHealthChecks("/api/hc");
                app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static async Task InitializeDb(WebApplication app)
        {
            Log.Information("Applying migrations...");
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (!context.Database.IsInMemory())
            {
                await context.Database.MigrateAsync();
            }
            
        }

        public static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }


    }
}
