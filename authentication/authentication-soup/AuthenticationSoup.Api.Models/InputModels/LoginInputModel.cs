using System.ComponentModel.DataAnnotations;

namespace AuthenticationSoup.Api.Models.InputModels;

public class LoginInputModel
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = null!;
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;
}