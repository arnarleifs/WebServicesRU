using RabbitMQ.Client.Events;

namespace StudentRegistration.UserService.Console.Handlers
{
    public interface IHandler
    {
        void Handle(BasicDeliverEventArgs arguments);
    }
}