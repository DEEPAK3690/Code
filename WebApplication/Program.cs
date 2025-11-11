//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

using MyWebApplication.Models;

namespace MyWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Register the EmployeeRepository for Dependency Injection
            builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddControllers();//Register all controller classes with the DI container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Middleware : :  When a request comes into your application, it passes through this pipeline of middleware components before generating a response.
            //is a check point for the request and response 
            // Request → Middleware 1 → Middleware 2 → Middleware 3 → Controller / Endpoint → Middleware 3 → Middleware 2 → Middleware 1 → Response

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
