using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Api.Handlers;
using PaymentProvider.DataAccessLayer.Services;
using PaymentProvider.Models.Dtos;
using PaymentProvider.Models.InputModels;

namespace PaymentProvider.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(PaymentLinksService paymentLinksService) : ControllerBase
{
    [ApiKeyAuthorize]
    [HttpPost("payment-links")]
    public async Task<ActionResult<PaymentLinkResponseDto>> CreatePaymentLink(
        [FromBody] PaymentLinkInputModel inputModel)
    {
        var customerIdClaim = User.FindFirst("CustomerId")?.Value;
        if (!int.TryParse(customerIdClaim, out var customerId))
        {
            return Unauthorized("Customer id could not be parsed");
        }

        var paymentLinkResponse = await paymentLinksService.CreatePaymentLinkAsync(inputModel, customerId);
        return Ok(paymentLinkResponse);
    }
}