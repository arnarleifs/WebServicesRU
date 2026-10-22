using Rebus.Config;
using Rebus.ServiceProvider;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Services.UserManagement;
using StargateUniversity.Software.Shared.Handlers;
using StargateUniversity.Software.UserRegistrations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<IAuth0ManagementService, Auth0ManagementService>(config =>
{
  config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Auth0:BaseUrl") ?? "");
}).AddHttpMessageHandler(_ => new ClientCredentialsHandler(
  clientId: builder.Configuration.GetValue<string>("Auth0:ClientId") ?? "",
  clientSecret: builder.Configuration.GetValue<string>("Auth0:ClientSecret") ?? "",
  audience: builder.Configuration.GetValue<string>("Auth0:Audience") ?? "",
  tokenEndpoint: builder.Configuration.GetValue<string>("Auth0:BaseUrl") ?? ""
));

builder.Services.AddRebus(
  configure => configure
    .Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMq") ?? "", QueueConstants.UserRegistrationsQueue)),
  onCreated: async bus =>
  {
    await bus.Subscribe<EmployeeRegistrationEvent>();
    await bus.Subscribe<StudentRegistrationEvent>();
  });
builder.Services.AddRebusHandler<UserRegistrationConsumer>();

builder.Services.AddLogging(configure => configure.AddConsole());

var host = builder.Build();
host.Run();
