namespace Fruityvice.Models.Dtos;

public class FruitDetailsDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Genus { get; set; }
    public string? Order { get; set; }
    public NutritionDto? Nutritions { get; set; }
}