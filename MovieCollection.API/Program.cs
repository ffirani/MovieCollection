using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using MovieCollection.API.Commands;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using Serilog;
using Serilog.Events;

namespace MovieCollection.API
{
    public class Program
    {
        public static void Main(string[] args)
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
                // Add services to the container.
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddCRUDCommands();
                builder.Services.AddExecutionContext();
                builder.Services.AddMediatR(cfg => {
                    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                });
                builder.Services.AddAutoMapper(typeof(Program),typeof(Entity));
                
                var app = builder.Build();
                
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

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
        static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
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
