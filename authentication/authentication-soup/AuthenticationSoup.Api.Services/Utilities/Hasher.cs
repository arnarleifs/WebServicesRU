using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AuthenticationSoup.Api.Services.Utilities;

public static class Hasher
{
    public static string HashPassword(string password, string salt)
    {
        const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
        const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
        const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits

        // Produce a version 2 (see comment above) text hash.
        var saltBytes = Encoding.ASCII.GetBytes(salt);
        byte[] subkey = KeyDerivation.Pbkdf2(password, saltBytes, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        var outputBytes = new byte[1 + salt.Length + Pbkdf2SubkeyLength];
        outputBytes[0] = 0x00; // format marker
        Buffer.BlockCopy(saltBytes, 0, outputBytes, 1, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 1 + salt.Length, Pbkdf2SubkeyLength);
        return Encoding.UTF8.GetString(outputBytes);
    }
}