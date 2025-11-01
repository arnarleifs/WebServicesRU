namespace StargateUniversity.PaymentGateway.Webhooks.Models;

public class PaymentLinkData
{
    public string PaymentLinkId { get; set; } = null!;
    public string Status { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
}