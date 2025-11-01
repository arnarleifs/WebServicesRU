using Microsoft.AspNetCore.Mvc;
using StargateUniversity.Software.API.Models;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(ILogger<EmployeesController> logger, IMessagingClient messagingClient) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeRegistrationInputModel inputModel)
    {
        var employeeEvent = new EmployeeRegistrationEvent
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Salary = inputModel.Salary,
            Currency = inputModel.Currency,
            Department = inputModel.Department
        };

        await messagingClient.PublishAsync<EmployeeRegistrationEvent>(employeeEvent, QueueConstants.ExchangeName, QueueConstants.EmployeeRegistrationTopic);

        return Created();
    }
}