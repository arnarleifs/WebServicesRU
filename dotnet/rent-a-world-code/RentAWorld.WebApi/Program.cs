using System.Reflection;
using RentAWorld.Repositories.Data;
using RentAWorld.Repositories.Implementations;
using RentAWorld.Repositories.Interfaces;
using RentAWorld.Services.Implementations;
using RentAWorld.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataProvider>();
builder.Services.AddTransient<IRentalRepository, RentalRepository>();
builder.Services.AddTransient<IRentalService, RentalService>();

builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
