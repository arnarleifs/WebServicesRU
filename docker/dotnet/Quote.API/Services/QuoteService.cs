using Quote.API.Data;
using Quote.API.Models;

namespace Quote.API.Services;

public class QuoteService : IQuoteService
{
    private readonly Quotes _quotes;

    public QuoteService(Quotes quotes)
    {
        _quotes = quotes;
    }

    public void CreateNewQuote(QuoteDto quote)
        => _quotes.quotes.Add(quote);

    public IEnumerable<QuoteDto> GetAllQuotes()
        => _quotes.quotes;
}