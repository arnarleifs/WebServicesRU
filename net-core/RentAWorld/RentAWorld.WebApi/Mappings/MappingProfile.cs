using System;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;

namespace RentAWorld.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rental, RentalDto>()
                .ForMember(src => src.AuthorStamp, opt => opt.MapFrom<AuthorStampResolver>());
            CreateMap<RentalInputModel, Rental>()
                .ForMember(src => src.DateCreated, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.DateModified, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "RentalAdmin"));
        }
    }
}