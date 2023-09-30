using System.Security.Claims;
using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSoup.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CookiesController : ControllerBase
{
    private readonly ICookieService _cookieService;

    public CookiesController(ICookieService cookieService)
    {
        _cookieService = cookieService;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] UserInputModel input)
    {
        _cookieService.RegisterUser(input);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginInputModel input)
    {
        var success = await _cookieService.LoginUser(input);
        return success ? Ok() : Unauthorized();
    }

    [Authorize]
    [HttpGet("claims")]
    public IActionResult DisplayClaims()
    {
        var user = new UserDto
        {
            FullName = User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value ?? "",
            EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "",
        };
        return Ok(user);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }
}
