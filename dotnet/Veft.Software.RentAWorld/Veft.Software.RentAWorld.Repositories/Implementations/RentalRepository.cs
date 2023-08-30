using AutoMapper;
using Veft.Software.RentAWorld.Models.Dtos;
using Veft.Software.RentAWorld.Models.Entities;
using Veft.Software.RentAWorld.Models.InputModels;
using Veft.Software.RentAWorld.Repositories.Data;
using Veft.Software.RentAWorld.Repositories.Interfaces;

namespace Veft.Software.RentAWorld.Repositories.Implementations
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IMapper _mapper;

        public RentalRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public int CreateRental(RentalInputModel rental)
        {
            var id = DataProvider.Rentals.Max(r => r.Id) + 1;

            var entity = _mapper.Map<Rental>(rental);

            // Update properties which are not a part of the input model
            entity.Id = id;
            entity.DateCreated = DateTime.Now;
            entity.DateModified = DateTime.Now;
            entity.ModifiedBy = "Postman";

            DataProvider.Rentals.Add(entity);

            return id;
        }

        public void DeleteRental(int id) => DataProvider.Rentals.RemoveAll(c => c.Id == id);

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
        {
            var rentals = containUnavailable ? DataProvider.Rentals : DataProvider.Rentals.Where(r => r.Available);
            return _mapper.Map<IEnumerable<RentalDto>>(rentals);
        }

        public RentalDto? GetRentalById(int id)
        {
            var rental = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<RentalDto>(rental);
        }

        public void UpdateRental(int id, RentalInputModel rental)
        {
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return; }

			// Update properties
			entity.Title = rental.Title;
			entity.Description = rental.Description;
			entity.AskingPrice = rental.AskingPrice.HasValue ? rental.AskingPrice.Value : 0;
			entity.Available = rental.Available.HasValue ? rental.Available.Value : true;
			entity.Address = rental.Address;
			entity.City = rental.City;
        }

        public void UpdateRentalPartially(int id, RentalInputModel rental)
        {
            var entity = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
			if (entity == null) { return; }

			// Update properties - if they are populated
			entity.Title = string.IsNullOrEmpty(rental.Title) ? entity.Title : rental.Title;
			entity.Description = string.IsNullOrEmpty(rental.Description) ? entity.Description : rental.Description;
			entity.AskingPrice = rental.AskingPrice.HasValue ? rental.AskingPrice.Value : entity.AskingPrice;
			entity.Available = rental.Available.HasValue ? rental.Available.Value : entity.Available;
			entity.Address = string.IsNullOrEmpty(rental.Address) ? entity.Address : rental.Address;
			entity.City = string.IsNullOrEmpty(rental.City) ? entity.City : rental.City;
        }
    }
}