using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentThePlace.Repositories.Data;

namespace RentAWorld.Repositories
{
    public class OwnerRepository
    {
        private IMapper _mapper;

        public OwnerRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<OwnerDto> GetOwnersByRentalId(int rentalId)
        {
            return _mapper.Map<IEnumerable<OwnerDto>>(DataProvider.Owners.Where(o => o.RentalId == rentalId));
        }

        public OwnerDto GetOwnerByRentalId(int rentalId, int ownerId)
        {
            var owner = DataProvider.Owners.FirstOrDefault(o => o.Id == ownerId && o.RentalId == rentalId);
            if (owner == null) { throw new Exception("Owner not found"); }
            return _mapper.Map<OwnerDto>(owner);
        }
    }
}