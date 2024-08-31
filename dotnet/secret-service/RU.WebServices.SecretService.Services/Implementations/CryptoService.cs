using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.Services.Implementations;

public class CryptoService : ICryptoService
{
    private readonly string _key = "mirlo_18592";

    public string Encrypt(string message)
    {
        if (message == null)
        {
            return null;
        }

        // Get the bytes of the string
        var bytesToBeEncrypted = Encoding.UTF8.GetBytes(message);
        var passwordBytes = Encoding.UTF8.GetBytes(_key);

        // Hash the password with SHA256
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

        return Convert.ToBase64String(bytesEncrypted);
    }

    public string Decrypt(string message)
    {
        if (message == null)
        {
            return null;
        }

        // Get the bytes of the string
        var bytesToBeDecrypted = Convert.FromBase64String(message);
        var passwordBytes = Encoding.UTF8.GetBytes(_key);

        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

        return Encoding.UTF8.GetString(bytesDecrypted);
    }

    private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using var ms = new MemoryStream();
        using var aes = Aes.Create();
        using var key =
            new Rfc2898DeriveBytes(passwordBytes, saltBytes, 10000, HashAlgorithmName.SHA256);

        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);

        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            cs.Close();
        }

        encryptedBytes = ms.ToArray();

        return encryptedBytes;
    }

    private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;

        var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using var ms = new MemoryStream();
        using var aes = Aes.Create();
        using var key =
            new Rfc2898DeriveBytes(passwordBytes, saltBytes, 10000, HashAlgorithmName.SHA256);

        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);
        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
            cs.Close();
        }

        decryptedBytes = ms.ToArray();

        return decryptedBytes;
    }
}