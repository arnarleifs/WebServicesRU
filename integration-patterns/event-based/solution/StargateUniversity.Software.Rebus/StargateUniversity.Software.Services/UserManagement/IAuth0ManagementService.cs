using StargateUniversity.Software.Contracts.Dtos.UserManagement;

namespace StargateUniversity.Software.Services.UserManagement;

public interface IAuth0ManagementService
{
    Task<UserCreationReturnDto?> CreateUser(NewUserInputModel inputModel);
    Task AddToEmployeeRole(string? userId);
}