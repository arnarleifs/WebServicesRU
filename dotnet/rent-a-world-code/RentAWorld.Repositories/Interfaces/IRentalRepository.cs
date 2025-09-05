using RentAWorld.Models.Dtos;
using RentAWorld.Models.InputModels;

namespace RentAWorld.Repositories.Interfaces;

public interface IRentalRepository
{
    IEnumerable<RentalDto> GetAllRentals(bool containUnavailable);
    RentalDto? GetRentalById(int id);
    int CreateNewRental(RentalInputModel inputModel);
    void UpdateRentalById(int id, RentalInputModel inputModel);
    void UpdateRentalPartiallyById(int id, RentalPartialInputModel inputModel);
    void DeleteRentalById(int id);
}