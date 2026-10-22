using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using StargateUniversity.Software.API.Models;
using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(ILogger<EmployeesController> logger, IBus bus) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeRegistrationInputModel inputModel)
    {
        await bus.Publish(new EmployeeRegistrationEvent
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Salary = inputModel.Salary,
            Currency = inputModel.Currency,
            Department = inputModel.Department
        });

        return Created();
    }
}
