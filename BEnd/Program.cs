using BEnd.Context;
using Microsoft.EntityFrameworkCore;

namespace BEnd
{
    class Programm
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ContextDB>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(ContextDB)));
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}