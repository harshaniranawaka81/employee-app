using EmployeeApp.Business.Services;
using EmployeeApp.Contracts.Repository;
using EmployeeApp.Contracts.Services;
using EmployeeApp.Entities.Models;
using EmployeeApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace EmployeeApp.Extensions
{
    public static class ServiceExtensions
    {

        /// <summary>
        /// Configure CORS policies
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configure the database connection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connecionString"></param>
        public static void ConfigureDb(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EmployeeAppDbContext>(
                options => options.UseSqlServer(connectionString, 
                    b => b.MigrationsAssembly("EmployeeApp")));
        }

        /// <summary>
        /// Configure the logging
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            var logFilePath = builder.Configuration["Logging:LogFilePath"];

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(formatter: new JsonFormatter())
                .CreateLogger();

            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console());
        } 

        /// <summary>
        /// Register all custom services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
