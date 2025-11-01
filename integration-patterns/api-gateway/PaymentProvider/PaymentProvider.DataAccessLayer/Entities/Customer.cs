namespace PaymentProvider.DataAccessLayer.Entities;

public class Customer
{
    public int Id { get; set; }
    public string ApiKey { get; set; } = null!;
    public string Name { get; set; } = null!;
}