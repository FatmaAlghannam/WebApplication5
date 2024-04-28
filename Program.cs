
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication5.Models;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Program.cs
            builder.Services.AddDbContext<BankContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefualtConnection"));
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });


            // Add services to the container.

            builder.Services.AddControllers()
            .AddXmlSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //=> security breach so hackers cant see direct the api :if 
            
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }
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
