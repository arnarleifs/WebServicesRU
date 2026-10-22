using Microsoft.Extensions.Options;
using Rebus.Config;
using Rebus.ServiceProvider;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.WelcomeLetters;
using StargateUniversity.Software.WelcomeLetters.Services.Mail;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("Mail"));
builder.Services.AddHttpClient<IMailService, MailService>((sp, client) =>
{
  client.BaseAddress = new Uri(sp.GetRequiredService<IOptions<MailOptions>>().Value.BaseUrl);
});

builder.Services.AddRebus(
  configure => configure
    .Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMq") ?? "", QueueConstants.WelcomeLettersQueue)),
  onCreated: async bus =>
  {
    await bus.Subscribe<EmployeeRegistrationEvent>();
    await bus.Subscribe<StudentRegistrationEvent>();
  });
builder.Services.AddRebusHandler<WelcomeLetterConsumer>();

builder.Services.AddLogging(configure => configure.AddConsole());

var host = builder.Build();
host.Run();
