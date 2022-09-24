using System.Text.Json.Serialization;

namespace Fruityvice.Models.Dtos;

public class NutritionDto
{
    [JsonPropertyName("carbohydrates")]
    public decimal Carbs { get; set; }
    public decimal Protein { get; set; }
    public decimal Fat { get; set; }
    public decimal Calories { get; set; }
    public decimal Sugar { get; set; }
}