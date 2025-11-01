using RabbitMQ.Client.Events;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.Consumers.Consumers.Base;

public abstract class RabbitMqConsumerService(IMessagingClient messagingClient, ILogger logger) : BackgroundService
{
    protected abstract string ExchangeName { get; }
    protected abstract string QueueName { get; }
    protected abstract string RoutingKey { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("{Consumer} starting to listen on queue: {Queue}", GetType().Name, QueueName);

        await messagingClient.SubscribeAsync<object>(ExchangeName, QueueName, HandleMessageAsync, RoutingKey);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    protected abstract Task HandleMessageAsync(object sender, BasicDeliverEventArgs args);
}