
using BlazingTrails.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BlazingTrailsContext>(options =>
                 options.UseSqlite(builder.Configuration.GetConnectionString("BlazingTrailsContext")));

            builder.Services.AddControllers();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
            app.MapFallbackToFile("index.html");


            

           

            app.Run();

        }
    }
}