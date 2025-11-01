using System.Text.Json;
using RabbitMQ.Client.Events;
using StargateUniversity.Software.Consumers.Consumers.Base;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Dtos.Financial;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Services.Financial;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.Consumers.Consumers;

public class RegistrationFinancialRecordConsumer(IMessagingClient messagingClient, IFinancialService financialService, ILogger<RegistrationFinancialRecordConsumer> logger) : RabbitMqConsumerService(messagingClient, logger)
{
    protected override string ExchangeName => QueueConstants.ExchangeName;

    protected override string QueueName => "financial-records";

    protected override string RoutingKey => QueueConstants.EmployeeRegistrationTopic;

    protected override async Task HandleMessageAsync(object sender, BasicDeliverEventArgs args)
    {
        Console.WriteLine($"[*] Processing user registrations with routing key {args.RoutingKey}");

        var employeeRegistrationEvent = JsonSerializer.Deserialize<EmployeeRegistrationEvent>(args.Body.ToArray());
        if (employeeRegistrationEvent == null)
        {
            throw new Exception("Employee registration event cannot be null");
        }

        await financialService.StoreFinancialRecord(new FinancialRecordCreationInputModel
        {
            FullName = employeeRegistrationEvent.FullName,
            EmailAddress = employeeRegistrationEvent.EmailAddress,
            Address = employeeRegistrationEvent.Address,
            PostalCode = employeeRegistrationEvent.PostalCode,
            City = employeeRegistrationEvent.City,
            Salary = employeeRegistrationEvent.Salary,
            Currency = employeeRegistrationEvent.Currency,
            Department = employeeRegistrationEvent.Department
        });

        Console.WriteLine($"[*] Processing user registrations with routing key {args.RoutingKey} completed");
    }
}