using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using StudentRegistration.UserService.Services.Helpers;
using StudentRegistration.UserService.Services.Interfaces;

namespace StudentRegistration.UserService.Services.Implementations
{
    public class QueueService : IQueueService, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchange;

        public QueueService(IConfiguration configuration) 
        {
            var messageBrokerSection = configuration.GetSection("MessageBroker");

            var host = messageBrokerSection.GetValue<string>("Host");
            _exchange = messageBrokerSection.GetValue<string>("Exchange");

            var factory = new ConnectionFactory() { HostName = host };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_exchange, "topic", true);
        }

        public void PublishTopic<T>(string routingKey, T data) where T : class =>
            _channel.BasicPublish(_exchange, routingKey, body: Encoding.UTF8.GetBytes(JsonSerializerHelper.SerializeWithCamelCasing(data)));

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}