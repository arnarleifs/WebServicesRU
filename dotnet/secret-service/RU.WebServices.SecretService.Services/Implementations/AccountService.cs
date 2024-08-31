using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Repositories.Interfaces;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public bool IsTokenBlacklisted(int tokenId)
    {
        return _accountRepository.IsTokenBlacklisted(tokenId);
    }

    public UserDto SignIn(LoginInputModel login)
    {
        return _accountRepository.SignIn(login);
    }

    public void SignOut(int tokenId)
    {
        _accountRepository.SignOut(tokenId);
    }
}