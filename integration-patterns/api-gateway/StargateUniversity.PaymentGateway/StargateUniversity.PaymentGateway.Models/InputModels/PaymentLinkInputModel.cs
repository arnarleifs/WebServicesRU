namespace StargateUniversity.PaymentGateway.Models.InputModels;

public class PaymentLinkInputModel
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
    public IEnumerable<PaymentLinkItemInputModel> Items { get; set; } = [];
}

public class PaymentLinkItemInputModel
{
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal AmountWithoutDiscount { get; set; }
    public decimal Amount { get; set; }
    public decimal UnitPrice { get; set; }
}