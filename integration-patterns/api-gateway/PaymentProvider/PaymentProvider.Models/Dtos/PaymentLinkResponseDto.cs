namespace PaymentProvider.Models.Dtos;

public class PaymentLinkResponseDto
{
    public string PaymentLinkIdentifier { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime ResponseTime { get; set; }
}