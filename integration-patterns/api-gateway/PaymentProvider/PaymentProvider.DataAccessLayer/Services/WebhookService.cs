using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PaymentProvider.DataAccessLayer.Contexts;
using PaymentProvider.DataAccessLayer.Utilities;
using PaymentProvider.Models.InputModels;

namespace PaymentProvider.DataAccessLayer.Services;

public class WebhookService(HmacSignatureUtility hmacSignatureUtility, PaymentProviderDbContext dbContext)
{
    public async Task CallCustomerWebhookAsync(PaymentLinkWebhookPayload payload, int customerId)
    {
        var webhookUrl = await GetWebhookUrlByCustomerIdAsync(customerId);
        if (string.IsNullOrEmpty(webhookUrl))
        {
            return;
        }

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(webhookUrl)
        };

        var signature = hmacSignatureUtility.GenerateSignature(JsonSerializer.Serialize(payload.Data));

        payload.Signature = signature;

        await httpClient.PostAsJsonAsync("", payload);
    }

    private async Task<string?> GetWebhookUrlByCustomerIdAsync(int customerId)
    {
        var webhook = await dbContext.Webhooks.FirstOrDefaultAsync(w => w.CustomerId == customerId);
        return webhook?.Url;
    }
}