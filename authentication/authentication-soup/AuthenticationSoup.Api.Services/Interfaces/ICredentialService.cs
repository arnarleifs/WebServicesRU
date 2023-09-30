using AuthenticationSoup.Api.Models.InputModels;

namespace AuthenticationSoup.Api.Services.Interfaces;

public interface ICredentialService
{
    public void RegisterUser(UserInputModel inputModel);
}