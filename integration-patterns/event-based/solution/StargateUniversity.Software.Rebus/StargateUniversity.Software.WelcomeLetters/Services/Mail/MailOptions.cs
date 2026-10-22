namespace StargateUniversity.Software.WelcomeLetters.Services.Mail;

public class MailOptions
{
    public string BaseUrl { get; set; } = null!;
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
}
