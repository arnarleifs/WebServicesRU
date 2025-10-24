using System.Text.Json;
using RabbitMQ.Client.Events;
using StargateUniversity.Software.Consumers.Consumers.Base;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Dtos.UserManagement;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Services.UserManagement;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.Consumers.Consumers;

public class UserRegistrationConsumer(
    IMessagingClient messagingClient,
    IAuth0ManagementService auth0ManagementService,
    ILogger<UserRegistrationConsumer> logger)
    : RabbitMqConsumerService(messagingClient, logger)
{
    protected override string ExchangeName => QueueConstants.ExchangeName;
    protected override string QueueName => "user-registrations";
    protected override string RoutingKey => "registrations.*";

    protected override async Task HandleMessageAsync(object sender, BasicDeliverEventArgs ea)
    {
        Console.WriteLine($"[*] Processing user registration with routing key {ea.RoutingKey}.");

        switch (ea.RoutingKey)
        {
            case QueueConstants.EmployeeRegistrationTopic:
            {
                var employeeRegistrationEvent =
                    JsonSerializer.Deserialize<EmployeeRegistrationEvent>(ea.Body.ToArray());
                if (employeeRegistrationEvent == null)
                {
                    throw new Exception("The employee registration event was null.");
                }

                var user = await auth0ManagementService.CreateUser(new NewUserInputModel
                {
                    Email = employeeRegistrationEvent.EmailAddress,
                    Name = employeeRegistrationEvent.FullName,
                    Nickname = employeeRegistrationEvent.EmailAddress,
                });
                
                await auth0ManagementService.AddToEmployeeRole(user?.UserId);
                break;
            }
            case QueueConstants.StudentRegistrationTopic:
            {
                var studentRegistrationEvent = JsonSerializer.Deserialize<StudentRegistrationEvent>(ea.Body.ToArray());
                if (studentRegistrationEvent == null)
                {
                    throw new Exception("The employee registration event was null.");
                }

                await auth0ManagementService.CreateUser(new NewUserInputModel
                {
                    Email = studentRegistrationEvent.EmailAddress,
                    Name = studentRegistrationEvent.FullName,
                    Nickname = studentRegistrationEvent.EmailAddress,
                });
                break;
            }
        }

        Console.WriteLine($"[*] Processing user registration with routing key {ea.RoutingKey} complete.");
    }
}