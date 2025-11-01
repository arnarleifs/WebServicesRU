using System.Security.Cryptography;
using System.Text;

namespace PaymentProvider.DataAccessLayer.Utilities;

/// <summary>
/// A utility class based around HMAC signatures using SHA256
/// </summary>
/// <param name="secretKey">A shared secret key used to validate the HMAC signature. The caller and callee must have the same shared key.</param>
public class HmacSignatureUtility(string secretKey)
{
    private readonly string _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));

    /// <summary>
    /// Generates an HMAC SHA256 signature for the given payload
    /// </summary>
    public string GenerateSignature(string payload)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        return Convert.ToBase64String(hash);
    }
}