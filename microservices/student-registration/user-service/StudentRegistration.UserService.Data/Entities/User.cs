namespace StudentRegistration.UserService.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";
    }
}