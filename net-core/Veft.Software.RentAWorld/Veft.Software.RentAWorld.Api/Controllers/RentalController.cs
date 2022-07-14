using Microsoft.AspNetCore.Mvc;
using Veft.Software.RentAWorld.Models.InputModels;
using Veft.Software.RentAWorld.Services.Interfaces;

namespace Veft.Software.RentAWorld.Api.Controllers;

[ApiController]
[Route("rentals")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAllRentals(
        [FromQuery] bool containUnavailable
    )
    {
        return Ok(_rentalService.GetAllRentals(containUnavailable));
    }

    [HttpGet]
    [Route("{id:int}", Name="GetRentalById")]
    public IActionResult GetRentalById(int id)
    {
        var rental = _rentalService.GetRentalById(id);
        if (rental == null) { return NotFound($"No rental found with id {id}"); }

        return Ok(rental);
    }

    [HttpPost]
    [Route("")]
    public IActionResult CreateNewRental([FromBody] RentalInputModel rental)
    {
        var newRentalId = _rentalService.CreateRental(rental);
        return CreatedAtRoute("GetRentalById", new { id = newRentalId }, null);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateRentalById([FromBody] RentalInputModel rental, int id)
    {
        _rentalService.UpdateRentalById(id, rental);
        return NoContent();
    }

    [HttpPatch]
    [Route("{id:int}")]
    public IActionResult UpdateRentalPartiallyById([FromBody] RentalInputModel rental, int id)
    {
        _rentalService.UpdateRentalPartially(id, rental);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteRentalById(int id)
    {
        _rentalService.DeleteRental(id);
        return NoContent();
    }
}
