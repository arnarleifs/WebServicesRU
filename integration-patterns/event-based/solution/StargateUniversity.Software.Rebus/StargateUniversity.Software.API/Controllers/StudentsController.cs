using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using StargateUniversity.Software.API.Models;
using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController(ILogger<StudentsController> logger, IBus bus) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistrationInputModel inputModel)
    {
        await bus.Publish(new StudentRegistrationEvent
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Semester = inputModel.Semester,
            Department = inputModel.Department
        });

        return Created();
    }
}
