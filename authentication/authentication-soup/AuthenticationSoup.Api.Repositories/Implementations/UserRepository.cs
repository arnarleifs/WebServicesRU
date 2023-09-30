using AuthenticationSoup.Api.Models.Dtos;
using AuthenticationSoup.Api.Models.Entities;
using AuthenticationSoup.Api.Models.InputModels;
using AuthenticationSoup.Api.Repositories.Contexts;
using AuthenticationSoup.Api.Repositories.Interfaces;

namespace AuthenticationSoup.Api.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AuthenticationDbContext _dbContext;

    public UserRepository(AuthenticationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserDto? GetUser(string emailAddress, string hashedPassword)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.EmailAddress == emailAddress && u.HashedPassword == hashedPassword);
        if (user == null) 
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress
        };
    }

    public void RegisterUser(UserInputModel inputModel, string hashedPassword)
    {
        if (_dbContext.Users.Any(u => u.EmailAddress == inputModel.EmailAddress))
        {
            return;
        }

        var entity = new User
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            HashedPassword = hashedPassword,
            RegistrationDate = DateTime.Now
        };

        _dbContext.Users.Add(entity);
        _dbContext.SaveChanges();
    }
}