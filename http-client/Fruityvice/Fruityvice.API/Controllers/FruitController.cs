using Fruityvice.Models.Enum;
using Fruityvice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fruityvice.API.Controllers
{
    [ApiController]
    [Route("fruits")]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllFruits() => Ok(await _fruitService.GetAllFruits());

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetFruitByName(string name) 
        {
            var fruit = await _fruitService.GetFruitByName(name);
            if (fruit == null) { return NotFound($"No fruit was found with name '{name}'"); }

            return Ok(fruit);
        }

        [HttpGet]
        [Route("{criteria}/{value}")]
        public async Task<IActionResult> GetFruitByCriteria(string criteria, string value)
        {
            if (!Enum.TryParse(typeof(FruitCriteriaEnum), criteria, true, out var enumValue))
            {
                return BadRequest($"Criteria '{criteria}' is not valid.");
            }

            var fruits = await _fruitService.GetFruitsByCriteria((FruitCriteriaEnum) enumValue, value);

            return Ok(fruits);
        }
    }
}