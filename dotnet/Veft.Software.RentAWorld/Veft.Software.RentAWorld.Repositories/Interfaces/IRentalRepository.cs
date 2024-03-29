using Veft.Software.RentAWorld.Models.Dtos;
using Veft.Software.RentAWorld.Models.InputModels;

namespace Veft.Software.RentAWorld.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        IEnumerable<RentalDto> GetAllRentals(bool containUnavailable);
        RentalDto? GetRentalById(int id);
        int CreateRental(RentalInputModel rental);
        void UpdateRental(int id, RentalInputModel rental);
        void UpdateRentalPartially(int id, RentalInputModel rental);
        void DeleteRental(int id);
    }
}