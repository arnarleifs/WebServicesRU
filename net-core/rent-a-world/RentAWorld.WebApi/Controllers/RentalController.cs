using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentAWorld.Models.InputModels;
using RentAWorld.Services.Interfaces;

namespace RentAWorld.WebApi.Controllers
{
	[ApiController]
	[Route("rentals")]
	public class RentalController : ControllerBase
	{
		private readonly IRentalService _rentalService;

		public RentalController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		// /rentals?containAvailable=true
		[HttpGet]
		[Route("")]
		public IActionResult GetAllRentals([FromQuery] bool containUnavailable)
		{
			return Ok(_rentalService.GetAllRentals(containUnavailable));
		}

		// /rentals/1
		[HttpGet]
		[Route("{id:int}", Name = "GetRentalById")]
		public IActionResult GetRentalById(int id)
		{
			return Ok(_rentalService.GetRentalById(id));
		}

		// /rentals
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewRental([FromBody] RentalInputModel rental)
		{
			var newId = _rentalService.CreateRental(rental);
			return Ok(newId);
		}

		// /rentals/1
		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateRentalById(int id, [FromBody] RentalInputModel rental)
		{
			_rentalService.UpdateRentalById(id, rental);
			return NoContent();
		}

		// /rentals/1
		[HttpPatch]
		[Route("{id:int}")]
		public IActionResult UpdateRentalPartiallyById(int id, [FromBody] RentalInputModel rental)
		{
			_rentalService.UpdateRentalPartially(id, rental);
			return NoContent();
		}

		// /rentals/1
		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteRentalById(int id)
		{
			_rentalService.DeleteRental(id);
			return NoContent();
		}
	}
}
