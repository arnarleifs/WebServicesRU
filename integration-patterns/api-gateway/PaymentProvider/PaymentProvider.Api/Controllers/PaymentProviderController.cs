using Microsoft.AspNetCore.Mvc;
using PaymentProvider.DataAccessLayer.Services;
using PaymentProvider.Models.Dtos;
using PaymentProvider.Models.InputModels;

namespace PaymentProvider.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentProviderController(PaymentLinksService paymentLinksService) : ControllerBase
{
    [HttpGet("payment-links/{id}")]
    public async Task<ActionResult<PaymentLinkItemDto>> GetPaymentLinkByIdentifier(string id)
    {
        var paymentLink = await paymentLinksService.GetPaymentLinkByIdentifierAsync(id);
        if (paymentLink == null)
        {
            return NotFound();
        }

        return Ok(paymentLink);
    }

    [HttpPost("payment-links/process")]
    public async Task<ActionResult> ProcessPaymentLink([FromBody] PaymentLinkProcessInputModel inputModel)
    {
        await paymentLinksService.ProcessPaymentLinkAsync(inputModel);
        return Ok();
    }
}