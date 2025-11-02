using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaymentProvider.DataAccessLayer.Services;

namespace PaymentProvider.Api.Handlers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ApiKeyAuthorizeAttribute>>();

        if (!context.HttpContext.Request.Headers.TryGetValue("X-Api-Key", out var apiKey))
        {
            logger.LogWarning("API Key missing from request");
            context.Result = new UnauthorizedObjectResult("API Key is missing");
            return;
        }

        var apiKeyValidator = context.HttpContext.RequestServices.GetRequiredService<ApiKeyValidatorService>();
        var validationResult = await apiKeyValidator.ValidateAsync(apiKey);

        if (!validationResult.IsValid)
        {
            logger.LogWarning("Invalid API Key attempted");
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
            return;
        }

        var claims = new List<Claim>
        {
            new("CustomerId", validationResult.CustomerId.ToString()),
            new(ClaimTypes.Name, validationResult.CustomerName)
        };

        var identity = new ClaimsIdentity(claims, "ApiKey");
        context.HttpContext.User = new ClaimsPrincipal(identity);
    }
}