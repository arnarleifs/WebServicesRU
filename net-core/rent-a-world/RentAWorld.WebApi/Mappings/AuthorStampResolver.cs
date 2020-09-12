using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;

namespace RentAWorld.WebApi.Mappings
{
    public class AuthorStampResolver : IValueResolver<Rental, RentalDto, string>
    {
        public string Resolve(Rental source, RentalDto destination, string destMember, ResolutionContext context)
        {
            return $"{source.ModifiedBy} - {source.DateModified.ToLongDateString()}";
        }
    }
}