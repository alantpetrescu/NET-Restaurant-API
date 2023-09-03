using Microsoft.AspNetCore.Mvc;
using NET_Ingredient_API.Services;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.DTOs.IngredientDTO;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet("getIngredient/{ingredientId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetIngredientByEmail([FromRoute] Guid ingredientId)
        {
            return Ok(_ingredientService.GetIngredient(ingredientId));
        }

        [HttpGet("getIngredients")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetIngredients()
        {
            return Ok(_ingredientService.GetAll().Result);
        }

        [HttpGet("getRecipesContainingIngredient/{ingredientName}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRecipesContainingIngredient([FromRoute] String ingredientName)
        {
            return Ok(_ingredientService.GetRecipesContainingIngredient(ingredientName));
        }

        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(IngredientCreateDTO ingredientCreateDTO)
        {
            IngredientResponseDTO ingredientResponseDTO = _ingredientService.Create(ingredientCreateDTO);
            return Ok(ingredientResponseDTO);
        }

        [HttpPost("update/{ingredientId}")]
        [Authorization(Role.Admin)]
        public IActionResult Update([FromRoute] Guid ingredientId, IngredientCreateDTO ingredientCreateDTO)
        {
            IngredientResponseDTO ingredientResponseDTO = _ingredientService.Update(ingredientId, ingredientCreateDTO);
            return Ok(ingredientResponseDTO);
        }

        [HttpPost("delete/{ingredientId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid ingredientId)
        {
            await _ingredientService.Delete(ingredientId);
            return Ok(_ingredientService.GetAll().Result);
        }
    }
}
