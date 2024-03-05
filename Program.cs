using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TunaPiano.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/artists/{artistId}", (TunaPianoDbContext db, int artistId) => //getSingleArtist
{ 
    return db.Artists.Include(a => a.Songs).Single(a => a.Id == artistId);
});

app.MapGet("/artists", (TunaPianoDbContext db) => //getAllArtists
{
    return db.Artists.ToList();
});

app.MapPost("/artists", (TunaPianoDbContext db, Artist newArtist) => //createNewArtist
{
    db.Artists.Add(newArtist);
    db.SaveChanges();
    return Results.Created($"/artists/{newArtist.Id}", newArtist);
});

app.MapDelete("/artists", (TunaPianoDbContext db, int artistId) =>
{
    var artistToDelete = db.Artists.Single(b => b.Id == artistId);
    db.Artists.Remove(artistToDelete);
});

app.MapPut("/artists", (TunaPianoDbContext db, int artistId, Artist updatedArtist) =>
{
    var artistToUpdate = db.Artists.Single(a => a.Id == artistId);
    artistToUpdate.Id = artistId;
    artistToUpdate.Name = updatedArtist.Name;
    artistToUpdate.Age = updatedArtist.Age;
    artistToUpdate.Bio = updatedArtist.Bio;
    db.SaveChanges();
    return Results.Created($"/artists/{updatedArtist.Id}", updatedArtist);
   
});

app.Run();