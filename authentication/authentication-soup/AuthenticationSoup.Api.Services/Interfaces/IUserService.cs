using System.Security.Claims;
using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;

namespace AuthenticationSoup.Api.Services.Interfaces;

public interface IUserService
{
    UserDto? LoginUser(LoginInputModel inputModel);
    void RegisterUser(UserInputModel inputModel);
    ClaimsPrincipal GeneratePrincipal(UserDto user, string authenticationScheme);
}