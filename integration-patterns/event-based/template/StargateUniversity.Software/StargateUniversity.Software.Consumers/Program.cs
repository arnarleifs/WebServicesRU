using RabbitMQ.Client;
using StargateUniversity.Software.Consumers.Consumers;
using StargateUniversity.Software.Services.UserManagement;
using StargateUniversity.Software.Shared.Handlers;
using StargateUniversity.Software.Shared.Queues;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<UserRegistrationConsumer>();

builder.Services.AddLogging(configure => configure.AddConsole());

builder.Services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactory
{
    HostName = builder.Configuration.GetValue<string>("RabbitMq:Host") ?? "",
    UserName = builder.Configuration.GetValue<string>("RabbitMq:User") ?? "",
    Password = builder.Configuration.GetValue<string>("RabbitMq:Password") ?? "",
});

builder.Services.AddSingleton<IMessagingClient, RabbitMqClient>();

builder.Services.AddHttpClient<IAuth0ManagementService, Auth0ManagementService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Auth0:BaseUrl") ?? "");
}).AddHttpMessageHandler(_ => new ClientCredentialsHandler(
    clientId: builder.Configuration.GetValue<string>("Auth0:ClientId") ?? "",
    clientSecret: builder.Configuration.GetValue<string>("Auth0:ClientSecret") ?? "",
    tokenEndpoint: builder.Configuration.GetValue<string>("Auth0:BaseUrl") ?? "",
    audience: builder.Configuration.GetValue<string>("Auth0:Audience") ?? ""
));

var host = builder.Build();
host.Run();