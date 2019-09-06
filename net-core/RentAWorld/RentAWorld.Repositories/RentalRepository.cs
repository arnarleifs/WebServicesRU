using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;
using RentThePlace.Repositories.Data;

namespace RentAWorld.Repositories
{
    public class RentalRepository
    {
        private IMapper _mapper;
        public RentalRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable) 
        {
            return _mapper.Map<IEnumerable<RentalDto>>(DataProvider.Rentals.Where(r => containUnavailable ? true : r.Available));
        }

        public RentalDto GetRentalById(int id)
        {
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<RentalDto>(entity);
        }

        public RentalDto CreateNewRental(RentalInputModel rental)
        {
            var nextId = DataProvider.Rentals.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = _mapper.Map<Rental>(rental);
            DataProvider.Rentals.Add(entity);
            return _mapper.Map<RentalDto>(entity);
        }

        public void UpdateRentalById(RentalInputModel rental, int id)
        {
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* Throw some exception */ }

            // Update properties
            entity.Title = rental.Title;
            entity.Description = rental.Description;
            entity.AskingPrice = rental.AskingPrice.HasValue ? rental.AskingPrice.Value : 0;
            entity.Available = rental.Available.HasValue ? rental.Available.Value : true;
            entity.Address = rental.Address;
            entity.City = rental.City;
            entity.DateModified = DateTime.Now;
        }

        public void UpdateRentalPartiallyById(RentalInputModel rental, int id)
        {
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* Throw some exception */ }

            // Update properties, if provided
            if (!string.IsNullOrEmpty(rental.Title)) { entity.Title = rental.Title; }
            if (!string.IsNullOrEmpty(rental.Description)) { entity.Description = rental.Description; }
            if (rental.AskingPrice.HasValue) { entity.AskingPrice = rental.AskingPrice.Value; }
            if (rental.Available.HasValue) { entity.Available = rental.Available.Value; }
            if (!string.IsNullOrEmpty(rental.Address)) { entity.Address = rental.Address; }
            if (!string.IsNullOrEmpty(rental.City)) { entity.City = rental.City; }
        }

        public void DeleteRentalById(int id)
        {
            // Method 1
            // DataProvider.Rentals.RemoveAll(r => r.Id == id);

            // Method 2
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* Throw some exception */ }
            DataProvider.Rentals.Remove(entity);
        }
    }
}