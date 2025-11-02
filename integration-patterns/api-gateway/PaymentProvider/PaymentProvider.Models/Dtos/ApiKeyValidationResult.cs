namespace PaymentProvider.Models.Dtos;

public class ApiKeyValidationResult
{
    public bool IsValid { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
}