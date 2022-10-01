using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Gateway.Models.InputModels;
using StudentRegistration.Gateway.Services.Interfaces;

namespace StudentRegistration.Gateway.Api.Controllers;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly IQueueService _queueService;

    public StudentController(IQueueService queueService)
    {
        _queueService = queueService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult RegisterStudent([FromBody] StudentRegistrationInputModel inputModel)
    {
        _queueService.PublishTopic<StudentRegistrationInputModel>("student-registration-request", inputModel);
        return StatusCode(201);
    }
}
