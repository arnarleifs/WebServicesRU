using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.InputModels;

namespace AuthenticationSoup.Api.Repositories.Interfaces;

public interface IUserRepository
{
    UserDto? GetUser(string emailAddress, string hashedPassword);
    void RegisterUser(UserInputModel inputModel, string hashedPassword);
}