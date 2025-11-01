namespace StargateUniversity.PaymentGateway.Models.Dtos;

public class PaymentLinkResponse
{
    public string PaymentLinkIdentifier { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime ResponseTime { get; set; }
}