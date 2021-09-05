using RentAWorld.Models.InputModels;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Repositories.Data;
using System.Collections.Generic;
using RentAWorld.Repositories.Interfaces;
using System.Linq;
using System;
using AutoMapper;

namespace RentAWorld.Repositories.Implementations
{
	public class RentalRepository : IRentalRepository
	{
		private readonly IMapper _mapper;

		public RentalRepository(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
		{
			return DataProvider.Rentals.Where(r => containUnavailable ? true : r.Available).Select(r => _mapper.Map<RentalDto>(r));
		}

		public RentalDto GetRentalById(int id)
		{
			var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return null; }
			return _mapper.Map<RentalDto>(entity);
		}

		public int CreateRental(RentalInputModel rental)
		{
			var max = DataProvider.Rentals.Select(r => r.Id).Max() + 1;

			var entity = _mapper.Map<Rental>(rental);

			entity.Id = max;
			entity.DateCreated = DateTime.Now;
			entity.DateModified = DateTime.Now;
			entity.ModifiedBy = "RentalAdmin";

			DataProvider.Rentals.Add(entity);

			return max;
		}

		public void UpdateRental(int id, RentalInputModel rental)
		{
			var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return; }

			// Update properties
			entity.Title = rental.Title;
			entity.Description = rental.Description;
			entity.AskingPrice = rental.AskingPrice.HasValue ? rental.AskingPrice.Value : 0;
			entity.Available = rental.Available.HasValue ? rental.Available.Value : true;
			entity.Address = rental.Address;
			entity.City = rental.City;
		}

		public void UpdateRentalPartially(int id, RentalInputModel rental)
		{
			var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return; }

			// Update properties - if they are populated
			entity.Title = string.IsNullOrEmpty(rental.Title) ? entity.Title : rental.Title;
			entity.Description = string.IsNullOrEmpty(rental.Description) ? entity.Description : rental.Description;
			entity.AskingPrice = rental.AskingPrice.HasValue ? rental.AskingPrice.Value : entity.AskingPrice;
			entity.Available = rental.Available.HasValue ? rental.Available.Value : entity.Available;
			entity.Address = string.IsNullOrEmpty(rental.Address) ? entity.Address : rental.Address;
			entity.City = string.IsNullOrEmpty(rental.City) ? entity.City : rental.City;
		}

		public void DeleteRental(int id)
		{
			var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return; }

			// Delete the entity
			DataProvider.Rentals.Remove(entity);
		}
	}
}