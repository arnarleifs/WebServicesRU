using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AuthenticationSoup.Api.Services.Implementations;

public class CookieService : ICookieService
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task<bool> LoginUser(LoginInputModel inputModel)
    {
        var user = _userService.LoginUser(inputModel);
        if (user == null)
        {
            return false;
        }

        var principal = _userService.GeneratePrincipal(user, CookieAuthenticationDefaults.AuthenticationScheme);

        if (_httpContextAccessor.HttpContext != null)
        {
            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);
        }

        return true;
    }

    public void RegisterUser(UserInputModel inputModel)
        => _userService.RegisterUser(inputModel);
}