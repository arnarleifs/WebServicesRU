using Microsoft.AspNetCore.Mvc;
using PaymentProvider.DataAccessLayer.Services;
using PaymentProvider.Models.InputModels;

namespace PaymentProvider.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(PaymentLinksService paymentLinksService) : ControllerBase
{
    [HttpPost("payment-links")]
    public async Task<ActionResult> CreatePaymentLink([FromBody] PaymentLinkInputModel inputModel)
    {
        await paymentLinksService.CreatePaymentLinkAsync(inputModel);

        return Created();
    }
}