using System.Security.Claims;
using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSoup.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TokensController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokensController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] UserInputModel input)
    {
        _tokenService.RegisterUser(input);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] LoginInputModel input)
    {
        var token = _tokenService.LoginUser(input);
        return Ok(token);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
}