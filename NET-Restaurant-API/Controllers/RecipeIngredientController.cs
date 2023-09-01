using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Helpers.Attributes;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.DTOs.RecipeIngredientDTO;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly RecipeIngredientService _recipeIngredientService;

        public RecipeIngredientController(RecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        [HttpGet("getRecipeIngredients")]
        [Authorization(Role.Admin, Role.User)]
        public IActionResult GetRecipeIngredients()
        {
            return Ok(_recipeIngredientService.GetAll().Result);
        }

        [HttpPost("create")]
        [Authorization(Role.Admin)]
        public IActionResult Create(RecipeIngredientDTO recipeIngredientDTO)
        {
            RecipeIngredientDTO recipeIngredientDTO2 = _recipeIngredientService.Create(recipeIngredientDTO);
            return Ok(recipeIngredientDTO2);
        }
    }
}
