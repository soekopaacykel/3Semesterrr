using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Kunde> kunder = new List<Kunde>
{
    new Kunde { Id = 1, Navn = "Hans", Email = "Hans@mail.dk", Type = "Privat" },
    new Kunde { Id = 2, Navn = "Emil", Email = "Emil@mail.dk", Type = "Privat" },
    new Kunde { Id = 3, Navn = "Katrine", Email = "Katrine@mail.dk", Type = "Erhverv" },
    new Kunde { Id = 4, Navn = "Emma", Email = "Emma@mail.dk", Type = "Privat" },
};

app.MapGet("/api/kunder", () => kunder); // Henter alle kunder

app.MapGet("/api/kunder/{id}", (long id) =>
{
    var kunde = kunder.FirstOrDefault(k => k.Id == id);
    return kunde is not null ? Results.Ok(kunde) : Results.NotFound();
}); // Henter en bestemt kunde ud fra ID

app.MapPost("/api/kunder", (Kunde newKunde) =>
{
    kunder.Add(newKunde);
    return Results.Created($"/api/kunder/{newKunde.Id}", newKunde);
}); // Tager imod en ny kunde der skal oprettes

app.MapDelete("/api/kunder/{id}", (long id) =>
{
    var kunde = kunder.FirstOrDefault(k => k.Id == id);
    if (kunde is not null)
    {
        kunder.Remove(kunde);
        return Results.NoContent();
    }
    return Results.NotFound();
}); // Sletter en bestemt kunde

app.MapGet("/api/emails/{type}", (string type) =>
{
    var emails = kunder.Where(k => k.Type == type).Select(k => k.Email).ToList();
    return Results.Ok(emails);
}); // Henter en liste over alle kunders email-adresser efter type

app.Run();

public class Kunde
{
    public long Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
}