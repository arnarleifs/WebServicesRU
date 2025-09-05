using Microsoft.AspNetCore.Mvc;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.InputModels;
using RentAWorld.Services.Interfaces;
using RentAWorld.WebApi.Models;

namespace RentAWorld.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalController(IRentalService rentalService) : ControllerBase
{
    // http://localhost:5223/rental
    [HttpGet("")]
    public ActionResult<IEnumerable<RentalDto>> GetAllRentals([FromQuery] bool containUnavailable)
    {
        return Ok(rentalService.GetAllRentals(containUnavailable));
    }

    // http://localhost:5223/rental/1
    [HttpGet("{id:int}", Name = "GetRentalById")]
    public ActionResult<RentalDto?> GetRentalById(int id)
    {
        var rental = rentalService.GetRentalById(id);
        if (rental == null)
        {
            return NotFound($"The rental with id {id} was not found.");
        }

        return Ok(rental);
    }

    // http://localhost:5223/rental
    [HttpPost("")]
    public ActionResult CreateNewRental([FromBody] RentalInputModel input)
    {
        var id = rentalService.CreateNewRental(input);
        return CreatedAtAction("GetRentalById", new { id }, null);
    }

    // http://localhost:5223/rental/1
    [HttpPut("{id:int}")]
    public ActionResult UpdateRentalById(int id, [FromBody] RentalInputModel inputModel)
    {
        rentalService.UpdateRentalById(id, inputModel);
        return NoContent();
    }

    // http://localhost:5223/rental/1
    [HttpPatch("{id:int}")]
    public ActionResult UpdateRentalPartiallyById(int id, [FromBody] RentalPartialInputModel inputModel)
    {
        rentalService.UpdateRentalPartiallyById(id, inputModel);
        return NoContent();
    }

    // http://localhost:5223/rental/1
    [HttpDelete("{id:int}")]
    public ActionResult DeleteRentalById(int id)
    {
        rentalService.DeleteRentalById(id);
        return NoContent();
    }
}
