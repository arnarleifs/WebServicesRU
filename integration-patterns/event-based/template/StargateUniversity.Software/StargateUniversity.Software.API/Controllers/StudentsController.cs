using Microsoft.AspNetCore.Mvc;
using StargateUniversity.Software.API.Models;
using StargateUniversity.Software.Contracts.Constants;
using StargateUniversity.Software.Contracts.Events;
using StargateUniversity.Software.Shared.Queues;

namespace StargateUniversity.Software.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController(ILogger<StudentsController> logger, IMessagingClient messagingClient) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistrationInputModel inputModel)
    {
        var employeeEvent = new StudentRegistrationEvent
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Semester = inputModel.Semester,
            Department = inputModel.Department
        };

        await messagingClient.PublishAsync<StudentRegistrationEvent>(employeeEvent, QueueConstants.ExchangeName, QueueConstants.StudentRegistrationTopic);

        return Created();
    }
}