namespace PaymentProvider.DataAccessLayer.Entities;

public class Webhook
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Url { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}