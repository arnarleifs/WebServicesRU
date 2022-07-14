namespace Veft.Software.RentAWorld.Models.Dtos
{
  public class RentalDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AskingPrice { get; set; }
        public bool Available { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}