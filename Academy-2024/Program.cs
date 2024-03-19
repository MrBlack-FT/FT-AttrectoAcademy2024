using Academy_2024.Data;
using Academy_2024.Options;
using Academy_2024.Repositories;
using Academy_2024.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Academy_2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen
            (
                c =>
                {
                    c.AddSecurityDefinition
                    (
                        "Bearer", new OpenApiSecurityScheme
                        {
                            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                              Enter 'Bearer' [space] and then your token in the text input below.
                              \r\n\r\nExample: 'Bearer 12345abcdef'",
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "Bearer"
                        }
                    );
                    c.AddSecurityRequirement
                    (
                        new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                     In = ParameterLocation.Header,
                                },
                                new List<string>()
                            }
                        }
                    );
                }
            );
            
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            
            builder.Services.AddScoped<IUserService, UserService>();

            //AddTransient külön objektumot hoz létre!
            builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();

            builder.Services.AddDbContext<ApplicationDbContext>
            (
                options => options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDBContext"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
