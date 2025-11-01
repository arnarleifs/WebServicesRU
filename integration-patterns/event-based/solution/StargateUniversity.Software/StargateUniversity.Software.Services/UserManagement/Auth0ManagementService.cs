using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using StargateUniversity.Software.Contracts.Dtos.UserManagement;

namespace StargateUniversity.Software.Services.UserManagement;

public class Auth0ManagementService(HttpClient httpClient, IConfiguration configuration) : IAuth0ManagementService
{
    private const string DefaultPassword = "Abc.12345";
    private const string AllowedConnection = "Username-Password-Authentication";
    private readonly string _employeeRoleId = configuration.GetValue<string>("Auth0:EmployeeRoleId") ?? "";

    public async Task<UserCreationReturnDto?> CreateUser(NewUserInputModel inputModel)
    {
        // Set default parameters for this case.
        inputModel.Password = DefaultPassword;
        inputModel.VerifyEmail = false;
        inputModel.Connection = AllowedConnection;

        var response = await httpClient.PostAsJsonAsync("/api/v2/users", inputModel);
        
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserCreationReturnDto>();
    }

    public async Task AddToEmployeeRole(string? userId)
    {
        var response = await httpClient.PostAsJsonAsync($"/api/v2/roles/{_employeeRoleId}/users", new RoleInputModel
        {
            Users = [userId ?? ""]
        });
        var content = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
    }
}