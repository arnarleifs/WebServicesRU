using Veft.Software.RentAWorld.Models.Dtos;
using Veft.Software.RentAWorld.Models.InputModels;
using Veft.Software.RentAWorld.Repositories.Interfaces;
using Veft.Software.RentAWorld.Services.Interfaces;

namespace Veft.Software.RentAWorld.Services.Implementations
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public int CreateRental(RentalInputModel rental) => _rentalRepository.CreateRental(rental);

        public void DeleteRental(int id) => _rentalRepository.DeleteRental(id);

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable) => _rentalRepository.GetAllRentals(containUnavailable);

        public RentalDto? GetRentalById(int id) => _rentalRepository.GetRentalById(id);

        public void UpdateRentalById(int id, RentalInputModel rental) => _rentalRepository.UpdateRental(id, rental);

        public void UpdateRentalPartially(int id, RentalInputModel rental) => _rentalRepository.UpdateRentalPartially(id, rental);
    }
}