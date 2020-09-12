using System.ComponentModel.DataAnnotations;

namespace RU.WebServices.SecretService.Models.InputModels
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}