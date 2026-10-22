using Rebus.Handlers;
using StargateUniversity.Software.Contracts.Dtos.UserManagement;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Services.UserManagement;

namespace StargateUniversity.Software.UserRegistrations;

public class UserRegistrationConsumer(IAuth0ManagementService auth0ManagementService, ILogger<UserRegistrationConsumer> logger)
    : IHandleMessages<EmployeeRegistrationEvent>, IHandleMessages<StudentRegistrationEvent>
{
    public async Task Handle(EmployeeRegistrationEvent message)
    {
        logger.LogInformation("Handling user registration for employee");

        var user = await auth0ManagementService.CreateUser(new NewUserInputModel
        {
            Email = message.EmailAddress,
            Name = message.FullName,
            Nickname = message.EmailAddress
        });

        await auth0ManagementService.AddToEmployeeRole(user?.UserId);
    }

    public async Task Handle(StudentRegistrationEvent message)
    {
        logger.LogInformation("Handling user registration for student");

        await auth0ManagementService.CreateUser(new NewUserInputModel
        {
            Email = message.EmailAddress,
            Name = message.FullName,
            Nickname = message.EmailAddress
        });
    }
}
