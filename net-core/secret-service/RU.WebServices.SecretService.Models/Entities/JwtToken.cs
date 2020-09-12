namespace RU.WebServices.SecretService.Models.Entities
{
    public class JwtToken
    {
        public int Id { get; set; }
        public bool Blacklisted { get; set; }
    }
}