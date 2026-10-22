using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.WelcomeLetters.Services.Mail;

public interface IMailService
{
    Task SendWelcomeLetter(EmployeeRegistrationEvent employee);

    Task SendWelcomeLetter(StudentRegistrationEvent student);
}
