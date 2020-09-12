using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.API.Controllers
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            var user = _accountService.SignIn(login);
            if (user == null) { return Unauthorized(); }
            return Ok(_tokenService.GenerateJwtToken(user));
        }

        [HttpGet]
        [Route("userinfo")]
        public IActionResult GetUserInfo()
        {
            var claims = User.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
            return Ok(claims);
        }

        [HttpGet]
        [Route("signout")]
        public IActionResult SignOut()
        {
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "tokenId").Value, out var tokenId);
            _accountService.SignOut(tokenId);
            return NoContent();
        }
    }
}