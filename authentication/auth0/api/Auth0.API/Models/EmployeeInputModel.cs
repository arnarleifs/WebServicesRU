using System.ComponentModel.DataAnnotations;

namespace Auth0.API.Models
{
    public class EmployeeInputModel
    {
        [Required]
        public string FullName { get; set; } = "";
        [Required]
        public string Title { get; set; } = "";
    }
}