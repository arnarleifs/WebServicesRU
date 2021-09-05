using RentAWorld.Models.InputModels;
using RentAWorld.Models.Dtos;
using System.Collections.Generic;

namespace RentAWorld.Services.Interfaces
{
    public interface IRentalService
    {
         IEnumerable<RentalDto> GetAllRentals(bool containUnavailable);
         RentalDto GetRentalById(int id);
         int CreateRental(RentalInputModel rental);
         void UpdateRentalById(int id, RentalInputModel rental);
         void UpdateRentalPartially(int id, RentalInputModel rental);
         void DeleteRental(int id);
    }
}