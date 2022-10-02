namespace StudentRegistration.UserService.Models.Transits
{
    public class StudentRegistrationTransit
    {
        public string Kennitala { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Username { get; set; }
        public string AppliedMajor { get; set; } = "";
        public int Price { get; set; }
        public string Semester { get; set; } = "";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }
}