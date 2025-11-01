using Microsoft.EntityFrameworkCore;
using PaymentProvider.DataAccessLayer.Contexts;
using PaymentProvider.Models.Dtos;
using PaymentProvider.Models.InputModels;

namespace PaymentProvider.DataAccessLayer.Services;

public class PaymentLinksService(WebhookService webhookService, PaymentProviderDbContext dbContext)
{
    public async Task<PaymentLinkDto?> GetPaymentLinkByIdentifierAsync(string id)
    {
        var paymentLink = await dbContext.PaymentLinks
            .Include(p => p.Customer)
            .Include(p => p.PaymentLinkItems)
            .FirstOrDefaultAsync(p => p.Identifier == id);

        if (paymentLink == null)
        {
            return null;
        }

        return new PaymentLinkDto
        {
            Identifier = paymentLink.Identifier,
            Url = paymentLink.Url,
            Processed = paymentLink.Processed,
            GeneratedDate = paymentLink.GeneratedDate,
            Customer = new CustomerDto
            {
                Name = paymentLink.Customer.Name,
            },
            Items = paymentLink.PaymentLinkItems.Select(pi => new PaymentLinkItemDto
            {
                ProductName = pi.ProductName,
                Quantity = pi.Quantity,
                Amount = pi.Amount,
                AmountWithoutDiscount = pi.AmountWithoutDiscount,
                UnitPrice = pi.UnitPrice,
            }).ToList()
        };
    }

    public async Task ProcessPaymentLinkAsync(PaymentLinkProcessInputModel inputModel)
    {
        var paymentLink =
            await dbContext.PaymentLinks.Include(paymentLink => paymentLink.PaymentLinkItems)
                .FirstOrDefaultAsync(p => p.Identifier == inputModel.PaymentLinkIdentifier);
        if (paymentLink == null)
        {
            throw new ArgumentException("Invalid payment link identifier.");
        }

        paymentLink.Processed = true;
        paymentLink.ProcessingDate = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        await webhookService.CallCustomerWebhookAsync(new PaymentLinkWebhookPayload
        {
            EventId = "Authorization",
            Type = "Success",
            Data = new PaymentLinkData
            {
                PaymentLinkId = inputModel.PaymentLinkIdentifier,
                Amount = paymentLink.PaymentLinkItems.Sum(pi => pi.Amount),
                Status = "Success",
                Currency = "ISK",
            }
        }, paymentLink.CustomerId);
    }
}