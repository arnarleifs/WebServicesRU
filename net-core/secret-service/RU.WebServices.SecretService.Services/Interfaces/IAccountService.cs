using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.InputModels;

namespace RU.WebServices.SecretService.Services.Interfaces
{
    public interface IAccountService
    {
        UserDto SignIn(LoginInputModel login);
        void SignOut(int tokenId);
        bool IsTokenBlacklisted(int tokenId);
    }
}