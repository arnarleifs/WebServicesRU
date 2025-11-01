namespace PaymentProvider.DataAccessLayer.Entities;

public class PaymentLink
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Identifier { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime ProcessingDate { get; set; }
    public DateTime GeneratedDate { get; set; }
    public bool Processed { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<PaymentLinkItem> PaymentLinkItems { get; set; } = new List<PaymentLinkItem>();
}