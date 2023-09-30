using System.ComponentModel.DataAnnotations;

namespace AuthenticationSoup.Api.Models.InputModels;

public class UserInputModel
{
    [Required]
    [MinLength(3)]
    public string FullName { get; set; } = "";
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = "";
    [Required]
    [MinLength(5)]
    public string Password { get; set; } = "";
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = "";
}