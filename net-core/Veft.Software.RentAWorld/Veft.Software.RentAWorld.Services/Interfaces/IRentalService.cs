using Veft.Software.RentAWorld.Models.Dtos;
using Veft.Software.RentAWorld.Models.InputModels;

namespace Veft.Software.RentAWorld.Services.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<RentalDto> GetAllRentals(bool containUnavailable);
        RentalDto? GetRentalById(int id);
        int CreateRental(RentalInputModel rental);
        void UpdateRentalById(int id, RentalInputModel rental);
        void UpdateRentalPartially(int id, RentalInputModel rental);
        void DeleteRental(int id);
    }
}