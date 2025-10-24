using RabbitMQ.Client;
using StargateUniversity.Software.Shared.Queues;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactory
{
    HostName = builder.Configuration.GetValue<string>("RabbitMq:Host") ?? "localhost",
    UserName = builder.Configuration.GetValue<string>("RabbitMq:User") ?? "",
    Password = builder.Configuration.GetValue<string>("RabbitMq:Password") ?? "",
});

builder.Services.AddSingleton<IMessagingClient, RabbitMqClient>();

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