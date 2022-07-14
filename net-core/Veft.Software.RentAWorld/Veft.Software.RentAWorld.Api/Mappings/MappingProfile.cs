using AutoMapper;
using Veft.Software.RentAWorld.Models.Dtos;
using Veft.Software.RentAWorld.Models.Entities;
using Veft.Software.RentAWorld.Models.InputModels;

namespace Veft.Software.RentAWorld.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rental, RentalDto>();
            CreateMap<RentalInputModel, Rental>();
        }
    }
}