using RabbitMQ.Client.Events;

namespace StargateUniversity.Software.Shared.Queues;

public interface IMessagingClient
{
    Task PublishAsync<T>(T data, string exchange, string routingKey = "");

    Task SubscribeAsync<T>(string exchange, string queue,
        Func<object, BasicDeliverEventArgs, Task> onConsume,
        string routingKey = "");
}