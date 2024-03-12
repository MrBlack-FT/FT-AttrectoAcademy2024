using Academy_2024.Data;
using Academy_2024.Repositories;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddSwaggerGen();

            //DEBUG! => MISSED LINE!
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
