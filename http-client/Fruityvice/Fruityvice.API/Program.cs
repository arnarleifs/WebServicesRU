using Fruityvice.Services.Implementations;
using Fruityvice.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Named client
// builder.Services.AddHttpClient("fruitApi", client => {
//     client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ExternalApiBaseUrl"));
// });

// Typed injection
builder.Services.AddHttpClient<IFruitService, FruitService>(client => {
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ExternalApiBaseUrl"));
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
