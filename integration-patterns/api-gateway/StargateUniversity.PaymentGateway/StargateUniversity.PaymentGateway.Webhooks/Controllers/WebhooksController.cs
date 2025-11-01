using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StargateUniversity.PaymentGateway.Webhooks.Models;
using StargateUniversity.PaymentGateway.Webhooks.Utilities;

namespace StargateUniversity.PaymentGateway.Webhooks.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhooksController(ILogger<WebhooksController> logger, HmacSignatureUtility utility) : ControllerBase
{
    [HttpPost("payment-link")]
    public async Task<ActionResult> ReceivePaymentLinkNotification([FromBody] PaymentLinkWebhookPayload payload)
    {
        logger.LogInformation($"Received payment link: {JsonSerializer.Serialize(payload)}");

        if (!utility.VerifySignature(JsonSerializer.Serialize(payload.Data), payload.Signature))
        {
            return BadRequest("The signatures did not match.");
        }

        // TODO: Process payments.

        return Ok();
    }
}