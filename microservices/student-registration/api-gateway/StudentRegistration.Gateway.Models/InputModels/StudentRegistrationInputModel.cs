using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Gateway.Models.InputModels
{
    public class StudentRegistrationInputModel
    {
        [Required]
        [RegularExpression("[0-9]{6}-?[0-9]{4}")]
        public string Kennitala { get; set; } = "";
        [Required]
        public string FullName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string AppliedMajor { get; set; } = "";
        [Required]
        public int Price { get; set; }
        [Required]
        public string Semester { get; set; } = "";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }
}