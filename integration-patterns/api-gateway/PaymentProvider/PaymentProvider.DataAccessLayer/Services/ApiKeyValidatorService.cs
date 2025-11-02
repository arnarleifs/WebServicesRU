using Microsoft.EntityFrameworkCore;
using PaymentProvider.DataAccessLayer.Contexts;
using PaymentProvider.Models.Dtos;

namespace PaymentProvider.DataAccessLayer.Services;

public class ApiKeyValidatorService(PaymentProviderDbContext dbContext)
{
    public async Task<ApiKeyValidationResult> ValidateAsync(string apiKey)
    {
        var customer = await dbContext.Customers
            .FirstOrDefaultAsync(c => c.ApiKey == apiKey);

        if (customer == null)
        {
            return new ApiKeyValidationResult { IsValid = false };
        }

        return new ApiKeyValidationResult
        {
            IsValid = true,
            CustomerId = customer.Id,
            CustomerName = customer.Name
        };
    }
}