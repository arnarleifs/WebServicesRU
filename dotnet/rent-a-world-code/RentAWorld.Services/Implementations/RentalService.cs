using RentAWorld.Models.Dtos;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories.Interfaces;
using RentAWorld.Services.Interfaces;

namespace RentAWorld.Services.Implementations;

public class RentalService(IRentalRepository rentalRepository) : IRentalService
{
    public int CreateNewRental(RentalInputModel inputModel)
        => rentalRepository.CreateNewRental(inputModel);

    public void DeleteRentalById(int id)
    {
        rentalRepository.DeleteRentalById(id);
    }

    public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
        => rentalRepository.GetAllRentals(containUnavailable);

    public RentalDto? GetRentalById(int id)
        => rentalRepository.GetRentalById(id);

    public void UpdateRentalById(int id, RentalInputModel inputModel)
    {
        rentalRepository.UpdateRentalById(id, inputModel);
    }

    public void UpdateRentalPartiallyById(int id, RentalPartialInputModel inputModel)
    {
        rentalRepository.UpdateRentalPartiallyById(id, inputModel);
    }
}