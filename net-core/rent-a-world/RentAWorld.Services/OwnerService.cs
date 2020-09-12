using System.Collections.Generic;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Repositories;

namespace RentAWorld.Services
{
    public class OwnerService
    {
        private OwnerRepository _ownerRepository;
        
        public OwnerService(IMapper mapper)
        {
            _ownerRepository = new OwnerRepository(mapper);
        }

        public IEnumerable<OwnerDto> GetOwnersByRentalId(int rentalId)
        {
            return _ownerRepository.GetOwnersByRentalId(rentalId);
        }
        public OwnerDto GetOwnerByRentalId(int rentalId, int ownerId)
        {
            return _ownerRepository.GetOwnerByRentalId(rentalId, ownerId);
        }
    }
}