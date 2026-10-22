using Rebus.Handlers;
using StargateUniversity.Software.WelcomeLetters.Services.Mail;
using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.WelcomeLetters;

public class WelcomeLetterConsumer(IMailService mailService, ILogger<WelcomeLetterConsumer> logger)
    : IHandleMessages<EmployeeRegistrationEvent>, IHandleMessages<StudentRegistrationEvent>
{
    public async Task Handle(EmployeeRegistrationEvent message)
    {
        logger.LogInformation("Sending employee welcome letter");
        await mailService.SendWelcomeLetter(message);
    }

    public async Task Handle(StudentRegistrationEvent message)
    {
        logger.LogInformation("Sending student welcome letter");
        await mailService.SendWelcomeLetter(message);
    }
}
