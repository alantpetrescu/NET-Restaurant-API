using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using NET_Restaurant_API.Models.DTOs.RecipeDTO;
using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Models.DTOs.IngredientDTO;

namespace NET_Restaurant_API.Services
{
    public class RecipeService
    {
        public RecipeRepository _recipeRepository;
        public IMapper _mapper;
        public RecipeService(RecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public List<RecipeResponseDTO> GetAll()
        {
            List<Recipe> recipes = _recipeRepository.GetAll().Result;
            List<RecipeResponseDTO> recipesResponseDTO = _mapper.Map<List<RecipeResponseDTO>>(recipes);

            return recipesResponseDTO;
        }

        public RecipeResponseDTO GetRecipe(Guid recipeId)
        {
            Recipe recipe = _recipeRepository.Get(recipeId);
            RecipeResponseDTO recipeResponseDTO = _mapper.Map<RecipeResponseDTO>(recipe);

            return recipeResponseDTO;
        }

        public List<IngredientResponseDTO> GetIngredientsFromRecipe(String recipeName)
        {
            var ingredientResponseDTO = _mapper.Map<List<IngredientResponseDTO>>(_recipeRepository.GetIngredientsFromRecipe(recipeName));

            return ingredientResponseDTO;
        }

        public RecipeResponseDTO Create(RecipeCreateDTO recipeCreateDTO)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeCreateDTO);
            // _databaseRepository.Create(employee);
            _recipeRepository.Create(recipe);
            _recipeRepository.Save();

            RecipeResponseDTO recipeResponseDTO = _mapper.Map<RecipeResponseDTO>(recipe);
            return recipeResponseDTO;
        }

        public RecipeResponseDTO Update(Guid recipeId, RecipeCreateDTO recipeCreateDTO)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeCreateDTO);
            // _databaseRepository.Create(employee);
            recipe.Id = recipeId;
            //recipe.DateCreated = DateTime.Now;

            _recipeRepository.Update(recipe);
            _recipeRepository.Save();

            RecipeResponseDTO recipeResponseDTO = _mapper.Map<RecipeResponseDTO>(recipe);
            return recipeResponseDTO;
        }

        public async Task Delete(Guid recipeId)
        {
            var recipeToDelete = await _recipeRepository.FindByIdAsync(recipeId);
            _recipeRepository.Delete(recipeToDelete);
            await _recipeRepository.SaveAsync();
        }
    }
}
