using GraphQlDemo.API.DataLoaders;
using GraphQlDemo.API.Schema.Mutation;
using GraphQlDemo.API.Schema.Query;
using GraphQlDemo.API.Schema.Subscription;
using GraphQlDemo.API.Services;
using GraphQlDemo.API.Services.Courses;
using GraphQlDemo.API.Services.Instructor;
using HotChocolate.Execution.Processing;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQlDemo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Connection to database --DI


            builder.Services.AddPooledDbContextFactory<SchoolDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
                       .EnableSensitiveDataLogging() // Optional for debugging
                       .LogTo(Console.WriteLine)     // Logs SQL queries to console
                       );

            //option.UseInMemoryDatabase("InMemory");
            #endregion

            #region Register Service
            builder.Services.AddScoped<CourseRepository>();
            builder.Services.AddScoped<InstructorRepository>();
            builder.Services.AddScoped<InatructorDataLoader>();
            #endregion


            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                 .AddInMemorySubscriptions(); // Add this to fix the issue
            ;

            var app = builder.Build();

            app.UseRouting();
            app.UseWebSockets();//add it when we dealing with subscribtion
            //app.MapGet("/", () => "Hello World!");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });



            app.Run();
        }
    }
}
