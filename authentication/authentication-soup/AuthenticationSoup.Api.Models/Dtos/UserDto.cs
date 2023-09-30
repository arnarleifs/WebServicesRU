namespace AuthenticationSoup.Api.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
}