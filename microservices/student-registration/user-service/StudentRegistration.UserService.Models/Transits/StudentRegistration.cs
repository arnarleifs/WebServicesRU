namespace StudentRegistration.UserService.Models.Transits
{
    public class StudentRegistration
    {
        public string Kennitala { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string AppliedMajor { get; set; } = "";
        public string Semester { get; set; } = "";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }
}