using Rebus.Config;

var builder = WebApplication.CreateBuilder(args);

// The API only publishes, so Rebus runs as a one-way client (no input queue)
builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseRabbitMqAsOneWayClient(builder.Configuration.GetConnectionString("RabbitMq") ?? "")));

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