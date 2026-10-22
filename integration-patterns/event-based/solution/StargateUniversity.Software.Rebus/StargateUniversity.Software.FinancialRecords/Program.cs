using Rebus.Config;
using Rebus.ServiceProvider;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.FinancialRecords;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddRebus(
  configure => configure
    .Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMq") ?? "", QueueConstants.FinancialRecordsQueue)),
  onCreated: bus => bus.Subscribe<EmployeeRegistrationEvent>());
builder.Services.AddRebusHandler<RegistrationFinancialRecordConsumer>();

builder.Services.AddLogging(configure => configure.AddConsole());

var host = builder.Build();
host.Run();
