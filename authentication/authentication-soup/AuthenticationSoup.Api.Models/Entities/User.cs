namespace AuthenticationSoup.Api.Models.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
}