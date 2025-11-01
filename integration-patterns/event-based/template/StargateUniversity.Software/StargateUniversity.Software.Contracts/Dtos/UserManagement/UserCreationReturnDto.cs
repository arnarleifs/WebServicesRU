using System.Text.Json.Serialization;

namespace StargateUniversity.Software.Contracts.Dtos.UserManagement;

public class UserCreationReturnDto
{
    [JsonPropertyName("user_id")] public string UserId { get; set; } = null!;
}