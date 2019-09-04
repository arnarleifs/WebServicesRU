using System.Collections.Generic;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories;

namespace RentAWorld.Services
{
    public class RentalService
    {
        private RentalRepository _rentalRepository;

        public RentalService(IMapper mapper)
        {
            _rentalRepository = new RentalRepository(mapper);
        }

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
        {
            return _rentalRepository.GetAllRentals(containUnavailable);
        }

        public RentalDto GetRentalById(int id)
        {
            return _rentalRepository.GetRentalById(id);
        }

        public RentalDto CreateNewRental(RentalInputModel rental)
        {
            return _rentalRepository.CreateNewRental(rental);
        }

        public void UpdateRentalById(RentalInputModel rental, int id)
        {
            _rentalRepository.UpdateRentalById(rental, id);
        }

        public void UpdateRentalPartiallyById(RentalInputModel rental, int id)
        {
            _rentalRepository.UpdateRentalPartiallyById(rental, id);
        }

        public void DeleteRentalById(int id)
        {
            _rentalRepository.DeleteRentalById(id);
        }
    }
}