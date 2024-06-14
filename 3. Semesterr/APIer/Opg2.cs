using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _3._Semesterr.APIer
{
    class Program
    {
        static string[] frugter = new string[]
        {
            "æble", "banan", "pære", "ananas"
        };

        record Fruit(string Name);

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Opgave 2.1
            app.MapGet("/api/hello", () => new { Message = "Hello World!" });

            // Opgave 3.1
            app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!" });

            // Opgave 3.2
            app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}, you are {age} years old!" });

            // Opgave 4
            app.MapGet("/api/fruit", () => frugter);

            app.MapGet("/api/fruit/{id}", (int id) =>
            {
                if (id < 0 || id >= frugter.Length)
                    return Results.NotFound();

                return frugter[id];
            });

            app.MapGet("/api/fruit/random", () =>
            {
                var random = new Random();
                return frugter[random.Next(frugter.Length)];
            });

            // Opgave 5 - POST endpoint for at tilføje en ny frugt
            app.MapPost("/api/fruit", (Fruit fruit) =>
            {
                var newFruitsList = frugter.ToList();
                newFruitsList.Add(fruit.Name);
                frugter = newFruitsList.ToArray();

                return new { Message = "Fruit added successfully", NewFruit = fruit };
            });

            app.Run();
        }
    }
}
