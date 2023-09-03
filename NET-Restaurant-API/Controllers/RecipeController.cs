using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models.DTOs.IngredientDTO;
using NET_Restaurant_API.Models.DTOs.RecipeDTO;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("getRecipes")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRecipes()
        {
            return Ok(_recipeService.GetAll());
        }

        [HttpGet("getRecipe/{recipeId}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRecipe([FromRoute] Guid recipeId)
        {
            return Ok(_recipeService.GetRecipe(recipeId));
        }

        [HttpGet("getIngredientsFromRecipe/{recipeName}")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetIngredientsFromRecipe([FromRoute] String recipeName)
        {
            return Ok(_recipeService.GetIngredientsFromRecipe(recipeName));
        }


        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(RecipeCreateDTO recipeCreateDTO)
        {
            RecipeResponseDTO recipeResponseDTO = _recipeService.Create(recipeCreateDTO);
            return Ok(recipeResponseDTO);
        }

        [HttpPost("update/{recipeId}")]
        [Authorization(Role.Admin)]
        public IActionResult Update([FromRoute] Guid recipeId, RecipeCreateDTO recipeCreateDTO)
        {
            RecipeResponseDTO recipeResponseDTO = _recipeService.Update(recipeId, recipeCreateDTO);
            return Ok(recipeResponseDTO);
        }

        [HttpPost("delete/{recipeId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid recipeId)
        {
            await _recipeService.Delete(recipeId);
            return Ok(_recipeService.GetAll());
        }
    }
}
