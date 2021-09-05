
using RentAWorld.Models.Entities;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.InputModels;
using AutoMapper;

namespace RentAWorld.WebApi.Profiles
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