using System.Reflection;
using Veft.Software.RentAWorld.Repositories.Implementations;
using Veft.Software.RentAWorld.Repositories.Interfaces;
using Veft.Software.RentAWorld.Services.Implementations;
using Veft.Software.RentAWorld.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IRentalService, RentalService>();
builder.Services.AddTransient<IRentalRepository, RentalRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
