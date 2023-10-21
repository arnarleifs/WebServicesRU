using Auth0.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth0.API.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<EmployeeDto> _employees = new()
        {
            new EmployeeDto
            {
                Id = 1,
                FullName = "John Doe",
                Title = "CTO"
            },
            new EmployeeDto
            {
                Id = 2,
                FullName = "Jane Doe",
                Title = "CEO"
            },
            new EmployeeDto
            {
                Id = 3,
                FullName = "Lisa Triangle",
                Title = "Clerk"
            },
            new EmployeeDto
            {
                Id = 4,
                FullName = "Moe Burlow",
                Title = "Librarian"
            },
        };

        [Authorize(Policy = "read:employees")]
        [HttpGet("")]
        public IActionResult GetAllEmployees()
            => Ok(_employees);

        [Authorize(Policy = "write:employees")]
        [HttpPost("")]
        public IActionResult CreateNewEmployee([FromBody] EmployeeInputModel inputModel)
        {
            var nextId = _employees.Max(e => e.Id) + 1;
            _employees.Add(new EmployeeDto
            {
                Id = nextId,
                FullName = inputModel.FullName,
                Title = inputModel.Title
            });

            return StatusCode(201);
        }
    }
}