using AuthenticationSoup.Api.Models.InputModels;

namespace AuthenticationSoup.Api.Services.Interfaces;

public interface ICookieService : ICredentialService
{
    Task<bool> LoginUser(LoginInputModel inputModel);
}