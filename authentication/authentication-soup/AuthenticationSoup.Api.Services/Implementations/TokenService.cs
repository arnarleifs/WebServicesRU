using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationSoup.Api.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IUserService _userService;
        private readonly string? _issuer;
        private readonly string _signingKey;

        public TokenService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;

            var jwtSection = configuration.GetSection("TokenAuthentication");
            _issuer = jwtSection.GetValue<string>("Issuer");
            _signingKey = jwtSection.GetValue<string>("SigningKey") ?? "";
        }

        public string LoginUser(LoginInputModel inputModel)
        {
            var user = _userService.LoginUser(inputModel) ?? throw new InvalidDataException();
            var principal = _userService.GeneratePrincipal(user, JwtBearerDefaults.AuthenticationScheme);

            return GenerateJwt(principal);
        }

        private string GenerateJwt(ClaimsPrincipal principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_issuer,
              _issuer,
              principal.Claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void RegisterUser(UserInputModel inputModel)
            => _userService.RegisterUser(inputModel);
    }
}