namespace RentAWorld.Models.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RentalId { get; set; }
    }
}