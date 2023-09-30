using AuthenticationSoup.Api.Models.InputModels;

namespace AuthenticationSoup.Api.Services.Interfaces;

public interface ITokenService : ICredentialService
{
    string LoginUser(LoginInputModel inputModel);
}