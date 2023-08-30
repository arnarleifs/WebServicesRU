using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MusicCaCaly.Repositories.Contexts;
using MusicCaCaly.Repositories.Implementations;
using MusicCaCaly.Repositories.Interfaces;
using MusicCaCaly.Services.Implementations;
using MusicCaCaly.Services.Interfaces;
using MusicCaCaly.WebApi.Converters;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<ISongService, SongService>();

// Repositories
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<ISongRepository, SongRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("MusicDbConnectionString"),
        b => b.MigrationsAssembly("MusicCaCaly.WebApi"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
