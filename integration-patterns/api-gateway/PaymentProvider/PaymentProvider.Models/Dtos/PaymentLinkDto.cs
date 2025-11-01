namespace PaymentProvider.Models.Dtos;

public class PaymentLinkDto
{
    public string Identifier { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime GeneratedDate { get; set; }
    public bool Processed { get; set; }
    public CustomerDto Customer { get; set; } = null!;
    public IEnumerable<PaymentLinkItemDto> Items { get; set; } = [];
}