using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TunaPiano;
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
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
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

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/song", (TunaPianoDbContext db) =>
{
    return db.Song.ToList();
});

app.MapPost("/song", (Song song , TunaPianoDbContext db) =>
{
    db.Song.Add(song);
    db.SaveChanges();

    return Results.Created($"/song/{song.Songid}", song);
});

app.MapDelete("/api/song/{Id}", (int sId, TunaPianoDbContext db) =>
{
    Song s = db.Song.FirstOrDefault(p => p.Songid == sId);

    if (s == null)
    {
        return Results.NotFound();
    }

    db.Song.Remove(s);
    db.SaveChanges();

    return Results.Ok(s);
});

app.MapPost("/api/SongGenre", (int Songid, int GenreId, TunaPianoDbContext db) =>
{
    var song = db.Song.Include(s => s.Genre).FirstOrDefault(s => s.Songid == Songid);

    if (song == null)
    {
        return Results.NotFound();
    }

    var genreToAdd = db.Genre.FirstOrDefault(g => g.GenreId == GenreId);

    if (genreToAdd == null)
    {
        return Results.NotFound();
    }

    song.Genre.Add(genreToAdd);
    db.SaveChanges();

    return Results.NoContent();
});


app.MapPut("/song/{Songid}", (int Songid, [FromBody] Song updatedSong, TunaPianoDbContext db) =>
{
    Song existingSong = db.Song.FirstOrDefault(s => s.Songid == Songid);

    if (existingSong == null)
    {
        return Results.NotFound();
    }

    existingSong.Title = updatedSong.Title;
    existingSong.ArtistId = updatedSong.ArtistId;
    existingSong.Album = updatedSong.Album;
    existingSong.length= updatedSong.length;

    db.SaveChanges();

    return Results.Ok(existingSong);
});

app.MapGet("/api/artist", (TunaPianoDbContext db) =>
{
    return db.Artist.ToList();
});

app.MapPost("/artist", (Artist artist, TunaPianoDbContext db) =>
{
    db.Artist.Add(artist);
    db.SaveChanges();

    return Results.Created($"/artist/{artist.ArtistId}", artist);
});

app.MapDelete("/api/artist/{Id}", (int artistId, TunaPianoDbContext db) =>
{
    Artist artist = db.Artist.FirstOrDefault(a => a.ArtistId == artistId);

    if (artist == null)
    {
        return Results.NotFound();
    }

    db.Artist.Remove(artist);
    db.SaveChanges();

    return Results.Ok(artist);
});

app.MapPut("/artist/{ArtistId}", (int ArtistId, [FromBody] Artist updatedArtist, TunaPianoDbContext db) =>
{
    Artist existingArtist = db.Artist.FirstOrDefault(a => a.ArtistId == ArtistId);

    if (existingArtist == null)
    {
        return Results.NotFound();
    }

    existingArtist.Name = updatedArtist.Name;
    existingArtist.Age = updatedArtist.Age;
    existingArtist.bio = updatedArtist.bio;

    db.SaveChanges();

    return Results.Ok(existingArtist);
});

app.MapGet("/api/genre", (TunaPianoDbContext db) =>
{
    return db.Genre.ToList();
});

app.MapPost("/genre", (Genre genre, TunaPianoDbContext db) =>
{
    db.Genre.Add(genre);
    db.SaveChanges();

    return Results.Created($"/genre/{genre.GenreId}", genre);
});

app.MapDelete("/api/genre/{Id}", (int genreId, TunaPianoDbContext db) =>
{
    Genre genre = db.Genre.FirstOrDefault(g => g.GenreId == genreId);

    if (genre == null)
    {
        return Results.NotFound();
    }

    db.Genre.Remove(genre);
    db.SaveChanges();

    return Results.Ok(genre);
});

app.MapPut("/genre/{GenreId}", (int GenreId, [FromBody] Genre updatedGenre, TunaPianoDbContext db) =>
{
    Genre existingGenre = db.Genre.FirstOrDefault(g => g.GenreId == GenreId);

    if (existingGenre == null)
    {
        return Results.NotFound();
    }

    existingGenre.Description = updatedGenre.Description;

    db.SaveChanges();

    return Results.Ok(existingGenre);
});

app.MapGet("/api/SongDetails", (int Songid, TunaPianoDbContext db) =>
{

    var song = db.Song.Where(s => s.Songid == Songid)
        .Include(s => s.Artist)
        .Include(s => s.Genre).ToList();
        

    if (song == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(song);
});

app.MapGet("/api/artist/{id}", (int ArtistId, TunaPianoDbContext db) =>
{
    var artist = db.Artist
        .Where(a => a.ArtistId == ArtistId)
        .Include(a => a.Song) 
       .FirstOrDefault();
    return artist; 
});


app.Run();
