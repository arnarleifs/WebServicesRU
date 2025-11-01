using System.ComponentModel.DataAnnotations;

namespace StargateUniversity.Software.API.Models;

public class StudentRegistrationInputModel
{
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 200 characters")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    [StringLength(320, ErrorMessage = "Email address cannot exceed 320 characters")]
    public string EmailAddress { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 500 characters")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required")]
    [RegularExpression(@"^\d{3,10}$", ErrorMessage = "Postal code must be between 3 and 10 digits")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Department is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Department must be between 2 and 100 characters")]
    public string Department { get; set; } = null!;

    [Required(ErrorMessage = "Semester is required")]
    [RegularExpression(@"^(Spring|Fall|Summer)\s\d{4}$",
        ErrorMessage = "Semester must be in format 'Spring 2024', 'Fall 2024', or 'Summer 2024'")]
    public string Semester { get; set; } = null!;
}