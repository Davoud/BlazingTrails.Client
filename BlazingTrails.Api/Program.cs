
using BlazingTrails.Api.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace BlazingTrails.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BlazingTrailsContext>(options =>
                 options.UseSqlite(builder.Configuration.GetConnectionString("BlazingTrailsContext")));

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(Program).Assembly));

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

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/Images")
            });

            app.UseRouting();

            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}