using Pomelo


using Doily.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Doily.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException("Connection string was not provided.");
            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddDbContext<DoilyContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
