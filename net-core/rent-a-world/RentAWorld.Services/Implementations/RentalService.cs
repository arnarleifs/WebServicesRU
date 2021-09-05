using RentAWorld.Models.InputModels;
using RentAWorld.Models.Dtos;
using System.Collections.Generic;
using RentAWorld.Services.Interfaces;
using RentAWorld.Repositories.Interfaces;

namespace RentAWorld.Services.Implementations
{
	public class RentalService : IRentalService
	{
		private readonly IRentalRepository _rentalRepository;

		public RentalService(IRentalRepository rentalRepository)
		{
			_rentalRepository = rentalRepository;
		}

		public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
		{
			return _rentalRepository.GetAllRentals(containUnavailable);
		}

		public RentalDto GetRentalById(int id)
		{
			return _rentalRepository.GetRentalById(id);
		}

		public int CreateRental(RentalInputModel rental)
		{
			return _rentalRepository.CreateRental(rental);
		}

		public void UpdateRentalById(int id, RentalInputModel rental)
		{
			_rentalRepository.UpdateRental(id, rental);
		}

		public void UpdateRentalPartially(int id, RentalInputModel rental)
		{
			_rentalRepository.UpdateRentalPartially(id, rental);
		}

		public void DeleteRental(int id)
		{
			_rentalRepository.DeleteRental(id);
		}
	}
}