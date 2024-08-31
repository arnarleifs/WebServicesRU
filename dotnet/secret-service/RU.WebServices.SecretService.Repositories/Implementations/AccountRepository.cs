using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using RU.WebServices.SecretService.Models.DTOs;
using RU.WebServices.SecretService.Models.Entities;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Repositories.Contexts;
using RU.WebServices.SecretService.Repositories.Interfaces;

namespace RU.WebServices.SecretService.Repositories.Implementations;

public class AccountRepository : IAccountRepository
{
    private readonly SecretServiceDbContext _dbContext;
    private string _salt = "00209b47-08d7-475d-a0fb-20abf0872ba0";

    public AccountRepository(SecretServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserDto SignIn(LoginInputModel login)
    {
        var user = _dbContext.Users.FirstOrDefault(u =>
            u.Email == login.Email &&
            u.HashedPassword == HashPassword(login.Password));
        if (user == null) { return null; }

        var token = new JwtToken();
        _dbContext.JwtTokens.Add(token);
        _dbContext.SaveChanges();

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            TokenId = token.Id
        };
    }

    public void SignOut(int tokenId)
    {
        var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
        if (token == null) { return; }
        token.Blacklisted = true;
        _dbContext.SaveChanges();
    }

    public bool IsTokenBlacklisted(int tokenId)
    {
        var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
        if (token == null) { return true; }
        return token.Blacklisted;
    }

    private string HashPassword(string password)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: CreateSalt(),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
    }

    private byte[] CreateSalt() =>
        Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(_salt)));
}