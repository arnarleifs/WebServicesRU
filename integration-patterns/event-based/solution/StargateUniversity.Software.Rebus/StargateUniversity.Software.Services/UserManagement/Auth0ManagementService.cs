using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using StargateUniversity.Software.Contracts.Dtos.UserManagement;

namespace StargateUniversity.Software.Services.UserManagement;

public class Auth0ManagementService(HttpClient httpClient, IConfiguration configuration) : IAuth0ManagementService
{
    private const string DefaultConnection = "Username-Password-Authentication";
    private const string DefaultPassword = "Abc.12345";
    private readonly string _employeeRoleId = configuration.GetValue<string>("Auth0:EmployeeRoleId") ?? "";

    public async Task<UserCreationReturnDto?> CreateUser(NewUserInputModel inputModel)
    {
        inputModel.Connection = DefaultConnection;
        inputModel.Password = DefaultPassword;
        inputModel.VerifyEmail = false;

        var content = await httpClient.PostAsJsonAsync("/api/v2/users", inputModel);
        return await content.Content.ReadFromJsonAsync<UserCreationReturnDto>();
    }

    public async Task AddToEmployeeRole(string? userId)
    {
        await httpClient.PostAsJsonAsync($"/api/v2/roles/{_employeeRoleId}/users", new RoleInputModel
        {
            Users = [userId ?? ""]
        });
    }
}