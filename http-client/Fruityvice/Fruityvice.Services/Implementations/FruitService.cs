using System.Net.Http.Json;
using Fruityvice.Models.Dtos;
using Fruityvice.Models.Enum;
using Fruityvice.Services.Interfaces;

namespace Fruityvice.Services.Implementations;

public class FruitService : IFruitService
{
    private HttpClient _httpClient;

    public FruitService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<FruitDto>?> GetAllFruits() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<FruitDto>>("fruit/all");

    public async Task<FruitDetailsDto?> GetFruitByName(string name)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<FruitDetailsDto>($"fruit/{name}");
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<IEnumerable<FruitDto>?> GetFruitsByCriteria(FruitCriteriaEnum criteria, string value) =>
        await _httpClient.GetFromJsonAsync<IEnumerable<FruitDto>>($"fruit/{criteria.ToString().ToLower()}/{value}");
}