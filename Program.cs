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

app.MapDelete("/artists", (TunaPianoDbContext db, int artistId) => //deleteArtist
{
    var artistToDelete = db.Artists.Single(b => b.Id == artistId);
    db.Artists.Remove(artistToDelete);
});

app.MapPut("/artists", (TunaPianoDbContext db, int artistId, Artist updatedArtist) => //updateArtist
{
    var artistToUpdate = db.Artists.Single(a => a.Id == artistId);
    artistToUpdate.Id = artistId;
    artistToUpdate.Name = updatedArtist.Name;
    artistToUpdate.Age = updatedArtist.Age;
    artistToUpdate.Bio = updatedArtist.Bio;
    db.SaveChanges();
    return Results.Created($"/artists/{updatedArtist.Id}", updatedArtist);
   
});

app.MapPut("/songs/{songId}/genre/{genreId}", (TunaPianoDbContext db, int songId, int genreId) => //associate song to genre
{

    Song songToAssociate = db.Songs.FirstOrDefault(s => s.Id == songId);
    if (songToAssociate == null)
    {
        return Results.NotFound("Song not found");
    }

    Genre genreToAssociate = db.Genres.FirstOrDefault(g => g.Id == genreId);

    if (genreToAssociate == null)
    {
        return Results.NotFound("Genre not found");
    }

    songToAssociate.Genres = new List<Genre>();

    songToAssociate.Genres.Add(genreToAssociate);

    db.SaveChanges();
    return Results.Created();
});

app.MapGet("/songs/{songId}", (TunaPianoDbContext db, int songId) => // get songs with artists and genres
{
    return db.Songs.Include(s => s.Artist).Include(s => s.Genres).FirstOrDefault(s => s.Id == songId);
});

app.MapGet("/songs/genre/{genreId}", (TunaPianoDbContext db, int genreId) => // get songs by genres
{
    return db.Genres.Include(s => s.Songs).Where(s => s.Id == genreId).ToList();
});

app.MapDelete("/songs", (TunaPianoDbContext db, int id) => //delete a song
{
    var songToDelete = db.Songs.FirstOrDefault(s => s.Id == id);
    if (songToDelete == null)
    {
        return Results.NotFound("There was an issue with deleting the song.");
    }
    else 
    {
        db.Songs.Remove(songToDelete);
        
        db.SaveChanges();
    }
    return Results.Ok();
});

app.MapGet("/artists{artistId}", (TunaPianoDbContext db, int artistId) =>// get all songs by artist
{
    return db.Artists.Include( s => s.Songs).ToList();
});

app.MapPost("/songs", (TunaPianoDbContext db, Song newSong) => //create new song
{
    db.Songs.Add(newSong);
    db.SaveChanges();
    return Results.Created("/songs/{newSong.Id}", newSong);
});

app.MapPatch("/songs/{songId}", (TunaPianoDbContext db, int songId, SongDto updatedSong) => // update song
{
    var songToUpdate = db.Songs.FirstOrDefault( s => s.Id == songId);
    songToUpdate.Title = updatedSong.Title;
    songToUpdate.ArtistId = updatedSong.ArtistId;
    songToUpdate.Album = updatedSong.Album;
    songToUpdate.Length = updatedSong.Length;
    db.SaveChanges();
    return Results.Ok();    

});

app.MapPost("/genre", (TunaPianoDbContext db, Genre newGenre) => //add new genre
{
    db.Genres.Add(newGenre);
    db.SaveChanges();
    return Results.Created("/genre/{genre.Id}", newGenre);
});

app.MapDelete("/genre/{genreId}", (TunaPianoDbContext db, int genreId) => // delete genre
{
   var genreToDelete = db.Genres.FirstOrDefault(g => g.Id == genreId);
    db.Genres.Remove(genreToDelete);
    db.SaveChanges();
});

app.MapPatch("/genre/{genreId}", (TunaPianoDbContext db, int genreId, Genre genrePayload) => // update genre
{
    var genreToUpdate = db.Genres.FirstOrDefault(gen => gen.Id == genreId);
    genreToUpdate.Id = genrePayload.Id;
    genreToUpdate.Description = genrePayload.Description;  
    db.SaveChanges();   
});

app.MapGet("/genre", (TunaPianoDbContext db) => // get all genres
{
    return db.Genres.ToList(); 

});

app.MapGet("/genre/{genreId}", (TunaPianoDbContext db, int genreId) => // get single genre and songs with it

{
    return db.Genres.Include(g => g.Songs).FirstOrDefault(s => s.Id == genreId);
});


app.Run();