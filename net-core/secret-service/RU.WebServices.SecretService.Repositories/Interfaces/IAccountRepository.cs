using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.InputModels;

namespace RU.WebServices.SecretService.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void SignOut(int tokenId);
        UserDto SignIn(LoginInputModel login);
        bool IsTokenBlacklisted(int tokenId);
    }
}