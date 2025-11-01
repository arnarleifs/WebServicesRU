namespace StargateUniversity.PaymentGateway.Webhooks.Models;

public class PaymentLinkWebhookPayload
{
    public string EventId { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Signature { get; set; } = null!;
    public PaymentLinkData Data { get; set; } = null!;
}