using Quote.API.Models;

namespace Quote.API.Services;

public interface IQuoteService
{
    IEnumerable<QuoteDto> GetAllQuotes();
    void CreateNewQuote(QuoteDto quote);
}