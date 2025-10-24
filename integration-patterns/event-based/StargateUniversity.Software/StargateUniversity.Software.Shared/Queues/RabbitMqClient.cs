using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace StargateUniversity.Software.Shared.Queues;

public class RabbitMqClient(IConnectionFactory connectionFactory) : IMessagingClient, IAsyncDisposable
{
    private readonly List<IConnection> _connections = [];
    private readonly List<IChannel> _subscriberChannels = [];

    public async Task PublishAsync<T>(T data, string exchange, string routingKey = "")
    {
        await using var connection = await connectionFactory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(exchange: exchange, type: ExchangeType.Topic, durable: true,
            autoDelete: false);

        await channel.BasicPublishAsync(exchange, routingKey, body: JsonSerializer.SerializeToUtf8Bytes(data));
    }

    public async Task SubscribeAsync<T>(string exchange, string queue,
        Func<object, BasicDeliverEventArgs, Task> onConsume,
        string routingKey = "")
    {
        var connection = await connectionFactory.CreateConnectionAsync();
        _connections.Add(connection);
        
        var channel = await connection.CreateChannelAsync();
        _subscriberChannels.Add(channel);

        await channel.ExchangeDeclareAsync(exchange: exchange, type: ExchangeType.Topic, durable: true,
            autoDelete: false);

        await channel.QueueDeclareAsync(queue: queue, durable: true, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queue: queue, exchange: exchange, routingKey: routingKey);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += onConsume.Invoke;

        await channel.BasicConsumeAsync(queue, autoAck: true, consumer: consumer);
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var channel in _subscriberChannels)
        {
            try
            {
                if (channel.IsOpen)
                    await channel.CloseAsync();
                await channel.DisposeAsync();
            }
            catch
            {
                // ignored
            }
        }
        _subscriberChannels.Clear();

        foreach (var connection in _connections)
        {
            try
            {
                if (connection.IsOpen)
                    await connection.CloseAsync();
                await connection.DisposeAsync();
            }
            catch
            {
                // ignored
            }
        }
        _connections.Clear();
    }
}
