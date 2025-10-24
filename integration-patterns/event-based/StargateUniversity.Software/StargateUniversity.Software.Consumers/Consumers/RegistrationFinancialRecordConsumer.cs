using RabbitMQ.Client.Events;
using StargateUniversity.Software.Consumers.Consumers.Base;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.Consumers.Consumers;

public class RegistrationFinancialRecordConsumer(IMessagingClient messagingClient, ILogger<RegistrationFinancialRecordConsumer> logger)
    : RabbitMqConsumerService(messagingClient, logger)
{
    protected override string ExchangeName => QueueConstants.ExchangeName;
    protected override string QueueName => "financial-records";
    protected override string RoutingKey => QueueConstants.EmployeeRegistrationTopic;

    protected override Task HandleMessageAsync(object sender, BasicDeliverEventArgs ea)
    {
        Console.WriteLine("Message received [X]");
        Console.WriteLine($"Routing key {ea.RoutingKey}");
        return Task.CompletedTask;
    }
}