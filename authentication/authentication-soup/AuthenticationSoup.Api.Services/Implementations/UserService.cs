using System.Security.Claims;
using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Repositories.Interfaces;
using AuthenticationSoup.Api.Services.Interfaces;
using AuthenticationSoup.Api.Services.Utilities;
using Microsoft.Extensions.Configuration;

namespace AuthenticationSoup.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _salt;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _salt = configuration.GetValue<string>("CookieAuthentication:Salt") ?? "";
        }

        public UserDto? LoginUser(LoginInputModel inputModel)
        {
            var hashedPassword = Hasher.HashPassword(inputModel.Password, _salt);
            var user = _userRepository.GetUser(inputModel.EmailAddress, hashedPassword);
            return user;
        }

        public void RegisterUser(UserInputModel inputModel)
        {
            var hashedPassword = Hasher.HashPassword(inputModel.Password, _salt);
            _userRepository.RegisterUser(inputModel, hashedPassword);
        }

        public ClaimsPrincipal GeneratePrincipal(UserDto user, string authenticationScheme)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.EmailAddress),
                new("FullName", user.FullName),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, authenticationScheme);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}