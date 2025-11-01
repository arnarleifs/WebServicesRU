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
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri(tokenEndpoint) };

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var accessToken = await GetTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string?> GetTokenAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "audience", audience },
        };

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/oauth/token");
            request.Content = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

            return content?.AccessToken;
        }
        catch (Exception)
        {
            // TODO: Handle gracefully
            return "";
        }
    }
}