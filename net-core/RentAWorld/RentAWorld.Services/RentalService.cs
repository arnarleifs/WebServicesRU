using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.HyperMedia;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories;

namespace RentAWorld.Services
{
    public class RentalService
    {
        private RentalRepository _rentalRepository;
        private OwnerRepository _ownerRepository;

        public RentalService(IMapper mapper)
        {
            _rentalRepository = new RentalRepository(mapper);
            _ownerRepository = new OwnerRepository(mapper);
        }

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
        {
            var rentals = _rentalRepository.GetAllRentals(containUnavailable).ToList();
            rentals.ForEach(r => {
                r.Links.AddReference("self", $"/api/rentals/{r.Id}");
                r.Links.AddListReference("owners", _ownerRepository.GetOwnersByRentalId(r.Id).Select(o => new { href = $"/api/rentals/{r.Id}/owners/{o.Id}" }));
            });
            return rentals;
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