using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudentRegistration.UserService.Console.Handlers;
using StudentRegistration.UserService.Data.Contexts;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (_, services) =>
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserDatabase"),
                    o => o.MigrationsAssembly("StudentRegistration.UserService.Console"));
            });
        }).Build();

var configSection = configuration.GetSection("MessageBroker");

var host = configSection.GetValue<string>("Host");
var exchange = configSection.GetValue<string>("Exchange");
var queue = configSection.GetValue<string>("Queue");

IAsyncConnectionFactory connectionFactory = new ConnectionFactory
{
    HostName = host
};

using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange, "topic", true);
channel.QueueDeclare(queue, true);
channel.QueueBind(queue, exchange, "student-registration-request");

Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var routingKey = ea.RoutingKey;

    Console.WriteLine($" [x] Received '{routingKey}'");

    HandlerFactory.GetHandlerByRoutingKey(routingKey, builder.Services)?.Handle(ea);

    Console.WriteLine($" [x] Processed '{routingKey}'");
};
channel.BasicConsume(queue,
    autoAck: true,
    consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();