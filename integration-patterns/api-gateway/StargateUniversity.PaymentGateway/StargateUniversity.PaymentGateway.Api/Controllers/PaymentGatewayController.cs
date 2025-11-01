using Microsoft.AspNetCore.Mvc;
using StargateUniversity.PaymentGateway.Commons.Clients;
using StargateUniversity.PaymentGateway.Models.InputModels;

namespace StargateUniversity.PaymentGateway.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(
    PaymentProviderClient paymentProviderClient) : ControllerBase
{
    [HttpPost("payment-links")]
    public async Task<ActionResult<string?>> GeneratePaymentLink([FromBody] PaymentLinkInputModel input)
    {
        var paymentLink = await paymentProviderClient.GeneratePaymentLink(input);
        return Ok(paymentLink);
    }
}