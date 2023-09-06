using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
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

app.MapPost("/api/song", (TunaPianoDbContext db, [FromBody] Song song) =>
{
    db.Song.Add(song);
    db.SaveChanges();

    return Results.Created($"/api/song/{song.Songid}", song);
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

app.MapPut("/api/songs/{songId}", (int songId, [FromBody] Song updatedSong, TunaPianoDbContext db) =>
{
    Song existingSong = db.Song.FirstOrDefault(s => s.Songid == songId);

    if (existingSong == null)
    {
        return Results.NotFound();
    }

    existingSong.Title = updatedSong.Title;
    existingSong.ArtistId = updatedSong.ArtistId;
    existingSong.Album = updatedSong.Album;
    existingSong.length= updatedSong.length;
    existingSong.Genre = updatedSong.Genre;

    db.SaveChanges();

    return Results.Ok(existingSong);
});


app.Run();
