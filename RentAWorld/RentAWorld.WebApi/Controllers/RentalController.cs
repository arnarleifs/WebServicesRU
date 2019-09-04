using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentAWorld.Models.InputModels;
using RentAWorld.Services;
using RentAWorld.WebApi.Models;

namespace RentAWorld.WebApi.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private RentalService _rentalService;
        public RentalController(IMapper mapper)
        {
            _rentalService = new RentalService(mapper);
        }

        // http://localhost:5000/api/rentals
        // http://localhost:5000/api/rentals?containUnavailable=false
        [Route("")]
        [HttpGet]
        public IActionResult GetAllRentals([FromQuery] bool containUnavailable) 
        {
            return Ok(_rentalService.GetAllRentals(containUnavailable));
        }

        // http://localhost:5000/api/rentals/4
        [Route("{id:int}", Name = "GetRentalById")]
        [HttpGet]
        public IActionResult GetRentalById(int id)
        {
            return Ok(_rentalService.GetRentalById(id));
        }

        // http://localhost:5000/api/rentals [POST]
        [Route("")]
        [HttpPost]
        public IActionResult CreateNewRental([FromBody] RentalInputModel body)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            
            var entity = _rentalService.CreateNewRental(body);

            return CreatedAtRoute("GetRentalById", new { id = entity.Id }, null);
        }

        // http://localhost:5000/api/rentals/1 [PUT]
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateRentalById([FromBody] RentalInputModel rental, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            
            _rentalService.UpdateRentalById(rental, id);

            return NoContent();
        }

        // http://localhost:5000/api/rentals/1 [PATCH]
        [Route("{id:int}")]
        [HttpPatch]
        public IActionResult UpdateRentalPartiallyById([FromBody] RentalInputModel rental, int id)
        {
            _rentalService.UpdateRentalPartiallyById(rental, id);

            return NoContent();
        }

        // http://localhost:5000/api/rentals/1 [DELETE]
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteRentalById(int id)
        {
            _rentalService.DeleteRentalById(id);
            return NoContent();
        }
    }
}
