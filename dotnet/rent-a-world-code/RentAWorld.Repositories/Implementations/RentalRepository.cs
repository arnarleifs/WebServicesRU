using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories.Data;
using RentAWorld.Repositories.Interfaces;

namespace RentAWorld.Repositories.Implementations;

public class RentalRepository(DataProvider dataProvider, IMapper mapper) : IRentalRepository
{
    public int CreateNewRental(RentalInputModel inputModel)
    {
        var nextId = dataProvider.Rentals.Max(m => m.Id) + 1;
        var entity = mapper.Map<Rental>(inputModel);

        entity.Id = nextId;

        dataProvider.Rentals.Add(entity);

        return nextId;
    }

    public void DeleteRentalById(int id)
    {
        var rental = dataProvider.Rentals.FirstOrDefault(r => r.Id == id);
        if (rental == null)
        {
            return;
        }

        dataProvider.Rentals.Remove(rental);
    }

    public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
    => dataProvider.Rentals.Where(r => containUnavailable || r.Available).Select(r => mapper.Map<RentalDto>(r));

    public RentalDto? GetRentalById(int id)
    {
        var rental = dataProvider.Rentals.FirstOrDefault(r => r.Id == id);
        if (rental == null)
        {
            return null;
        }

        return mapper.Map<RentalDto>(rental);
    }

    public void UpdateRentalById(int id, RentalInputModel inputModel)
    {
        var rental = dataProvider.Rentals.FirstOrDefault(r => r.Id == id);
        if (rental == null)
        {
            return;
        }

        // Update properties
        rental.Title = inputModel.Title;
        rental.Description = inputModel.Description;
        rental.AskingPrice = inputModel.AskingPrice;
        rental.Available = inputModel.Available;
        rental.Address = inputModel.Address;
        rental.City = inputModel.City;
        rental.ModifiedBy = "Admin";
        rental.DateModified = DateTime.Now;
    }

    public void UpdateRentalPartiallyById(int id, RentalPartialInputModel inputModel)
    {
        var rental = dataProvider.Rentals.FirstOrDefault(r => r.Id == id);
        if (rental == null)
        {
            return;
        }

        // Update properties
        if (inputModel.Title != null)
        {
            rental.Title = inputModel.Title;
        }

        if (inputModel.Description != null)
        {
            rental.Description = inputModel.Description;
        }

        if (inputModel.AskingPrice.HasValue)
        {
            rental.AskingPrice = inputModel.AskingPrice.Value;
        }

        if (inputModel.Available.HasValue)
        {
            rental.Available = inputModel.Available.Value;
        }

        if (inputModel.Address != null)
        {
            rental.Address = inputModel.Address;
        }

        if (inputModel.City != null)
        {
            rental.City = inputModel.City;
        }
        
        rental.ModifiedBy = "Admin";
        rental.DateModified = DateTime.Now;
    }
}