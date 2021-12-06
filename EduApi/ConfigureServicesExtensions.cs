using EduApi.Data;
using EduApi.Entities;
using EduApi.Models.Repositories;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EduApi
{
    public static class ConfigureServicesExtensions
    {
        public static void AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration, Startup startup)
        {
            services.AddDbContext<EduDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<EduSeeder>();
            services.AddAutoMapper(startup.GetType().Assembly);
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IMaterialTypeRepository, MaterialTypeRepository>();
            services.AddScoped<IMaterialrRepository, MaterialRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }

        //public static void AddValidationLayer(this IServiceCollection services)
        //{
        //    services.AddScoped<ErrorHandlingMiddleware>();
        //    services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        //    services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        //    services.AddScoped<IValidator<SeriesQuery>, SeriesQueryValidator>();
        //}

        //public static void AddAuthenticationLayer(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var authenticationSettings = new AuthenticationSettings();
        //    configuration.GetSection("Authentication").Bind(authenticationSettings);
        //    services.AddSingleton(authenticationSettings);
        //    services.AddAuthentication(option =>
        //    {
        //        option.DefaultAuthenticateScheme = "Bearer";
        //        option.DefaultScheme = "Bearer";
        //        option.DefaultChallengeScheme = "Bearer";
        //    }).AddJwtBearer(cfg =>
        //    {
        //        cfg.RequireHttpsMetadata = false;
        //        cfg.SaveToken = true;
        //        cfg.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidIssuer = authenticationSettings.JwtIssuer,
        //            ValidAudience = authenticationSettings.JwtIssuer,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
        //        };
        //    });
        //}

        public static void AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", builder =>
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["AllowedOrigins"])
                    );
            });
        }
    }
}
