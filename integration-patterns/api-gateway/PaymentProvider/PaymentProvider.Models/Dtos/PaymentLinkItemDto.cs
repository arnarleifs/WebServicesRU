namespace PaymentProvider.Models.Dtos;

public class PaymentLinkItemDto
{
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal AmountWithoutDiscount { get; set; }
    public decimal Amount { get; set; }
    public decimal UnitPrice { get; set; }
}