using System.Text.Json.Serialization;

namespace StargateUniversity.Software.Contracts.Dtos.UserManagement;

public class RoleInputModel
{
    [JsonPropertyName("users")]
    public List<string> Users { get; set; } = [];
}