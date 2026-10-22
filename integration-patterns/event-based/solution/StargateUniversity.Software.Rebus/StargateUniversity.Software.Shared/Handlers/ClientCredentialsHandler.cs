using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace StargateUniversity.Software.Shared.Handlers;

public class AccessTokenResponse
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; } = null!;
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = null!;
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}

public class ClientCredentialsHandler(string clientId, string clientSecret, string audience, string tokenEndpoint)
    : DelegatingHandler
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(tokenEndpoint)
    };

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await GetTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string?> GetTokenAsync()
    {
        var securityParams = new Dictionary<string, string>
        {
            { "client_id", clientId },
            { "client_secret", clientSecret},
            { "audience", audience },
            { "grant_type", "client_credentials" }
        };

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "oauth/token");
            var formValues = new FormUrlEncodedContent(securityParams);
            request.Content = formValues;
            var response = await _httpClient.SendAsync(request);

            var token = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

            return token?.AccessToken;
        }
        catch (Exception)
        {
            // Handle gracefully
            return "";
        }
    }
}