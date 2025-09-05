using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;

namespace RentAWorld.WebApi.Mappings;

public class RentalMappings : Profile
{
    public RentalMappings()
    {
        CreateMap<Rental, RentalDto>();
        CreateMap<RentalInputModel, Rental>().ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));
    }
}