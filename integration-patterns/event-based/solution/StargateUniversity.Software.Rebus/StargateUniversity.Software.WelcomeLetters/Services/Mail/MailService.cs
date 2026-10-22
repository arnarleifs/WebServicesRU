using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.WelcomeLetters.Services.Mail;

public class MailService(HttpClient httpClient, IOptions<MailOptions> options) : IMailService
{
    private const string Subject = "Welcome to Stargate University";
    private readonly MailOptions _options = options.Value;

    public Task SendWelcomeLetter(EmployeeRegistrationEvent employee) =>
        SendAsync(employee.FullName, employee.EmailAddress, "EmployeeWelcomeLetter.html", new Dictionary<string, string>
        {
            ["FullName"] = employee.FullName,
            ["Department"] = employee.Department
        });

    public Task SendWelcomeLetter(StudentRegistrationEvent student) =>
        SendAsync(student.FullName, student.EmailAddress, "StudentWelcomeLetter.html", new Dictionary<string, string>
        {
            ["FullName"] = student.FullName,
            ["Department"] = student.Department,
            ["Semester"] = student.Semester
        });

    private async Task SendAsync(string recipientName, string recipientEmail, string template,
        Dictionary<string, string> placeholders)
    {
        var html = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, "Templates", template));

        foreach (var (key, value) in placeholders)
        {
            html = html.Replace($"{{{{{key}}}}}", System.Net.WebUtility.HtmlEncode(value));
        }

        // Mailpit send API: https://mailpit.axllent.org/docs/api-v1/
        var response = await httpClient.PostAsJsonAsync("api/v1/send", new
        {
            From = new { Email = _options.SenderEmail, Name = _options.SenderName },
            To = new[] { new { Email = recipientEmail, Name = recipientName } },
            Subject,
            HTML = html
        });

        response.EnsureSuccessStatusCode();
    }
}
