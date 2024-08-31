namespace RU.WebServices.SecretService.Services.Interfaces;

public interface ICryptoService
{
    string Decrypt(string message);
    string Encrypt(string message);
}