using RU.WebServices.SecretService.Models.DTOs;

namespace RU.WebServices.SecretService.Services.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(UserDto user);
}