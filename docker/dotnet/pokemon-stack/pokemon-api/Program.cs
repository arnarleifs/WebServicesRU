using Microsoft.EntityFrameworkCore;
using pokemon_api.Contexts;
using pokemon_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PokemonDatabaseConnectionString")
    )
);

builder.Services.AddHttpClient<IPokemonService, PokemonService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("PokemonImageApiBaseUrl") ?? "");
});

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
