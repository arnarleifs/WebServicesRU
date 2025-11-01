using System.Net.Http.Json;
using StargateUniversity.PaymentGateway.Models.Dtos;
using StargateUniversity.PaymentGateway.Models.InputModels;

namespace StargateUniversity.PaymentGateway.Commons.Clients;

public class PaymentProviderClient(HttpClient httpClient)
{
    public async Task<string?> GeneratePaymentLink(PaymentLinkInputModel input)
    {
        var response = await httpClient.PostAsJsonAsync("payment-links", input);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<PaymentLinkResponse>();
        return content?.Url;
    }
}