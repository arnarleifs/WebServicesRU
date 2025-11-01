namespace PaymentProvider.Models.InputModels;

public class PaymentLinkProcessInputModel
{
    public string CreditCardNumber { get; set; } = null!;
    public string Expiry { get; set; } = null!;
    public string Cvc { get; set; } = null!;
    public string PaymentLinkIdentifier { get; set; } = null!;
}