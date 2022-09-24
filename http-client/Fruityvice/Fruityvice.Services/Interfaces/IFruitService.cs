using Fruityvice.Models.Dtos;
using Fruityvice.Models.Enum;

namespace Fruityvice.Services.Interfaces;

public interface IFruitService
{
    Task<IEnumerable<FruitDto>?> GetAllFruits();
    Task<FruitDetailsDto?> GetFruitByName(string name);
    Task<IEnumerable<FruitDto>?> GetFruitsByCriteria(FruitCriteriaEnum criteria, string value);
}