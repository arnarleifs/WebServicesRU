using System.Security.Cryptography;
using System.Text;

namespace StargateUniversity.PaymentGateway.Webhooks.Utilities;

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
    private string GenerateSignature(string payload)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Verifies if the provided signature matches the payload
    /// </summary>
    public bool VerifySignature(string payload, string signature)
    {
        if (string.IsNullOrEmpty(signature))
            return false;

        var expectedSignature = GenerateSignature(payload);
        return SecureCompare(expectedSignature, signature);
    }

    /// <summary>
    /// Timing-safe string comparison to prevent timing attacks
    /// </summary>
    private bool SecureCompare(string a, string b)
    {
        if (a.Length != b.Length)
            return false;

        var result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result |= a[i] ^ b[i];
        }

        return result == 0;
    }
}