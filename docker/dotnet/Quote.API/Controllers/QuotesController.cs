using Microsoft.AspNetCore.Mvc;
using Quote.API.Models;
using Quote.API.Services;

namespace Quote.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService _quoteService;

    public QuotesController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [HttpGet("")]
    public IActionResult GetAllQuotes()
        => Ok(_quoteService.GetAllQuotes());

    [HttpPost("")]
    public IActionResult CreateQuote([FromBody] QuoteDto quote)
    {
        _quoteService.CreateNewQuote(quote);
        return StatusCode(201);
    }
}
