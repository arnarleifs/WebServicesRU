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
        var studentEvent = new StudentRegistrationEvent
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Department = inputModel.Department,
            Semester = inputModel.Semester
        };

        await messagingClient.PublishAsync(studentEvent, QueueConstants.ExchangeName,
            QueueConstants.StudentRegistrationTopic);

        return Created();
    }
}