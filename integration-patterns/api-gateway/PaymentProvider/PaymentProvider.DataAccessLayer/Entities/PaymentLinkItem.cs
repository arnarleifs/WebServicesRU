namespace PaymentProvider.DataAccessLayer.Entities;

public class PaymentLinkItem
{
    public int Id { get; set; }
    public int PaymentLinkId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal AmountWithoutDiscount { get; set; }
    public decimal Amount { get; set; }
    public decimal UnitPrice { get; set; }

    public virtual PaymentLink PaymentLink { get; set; } = null!;
}