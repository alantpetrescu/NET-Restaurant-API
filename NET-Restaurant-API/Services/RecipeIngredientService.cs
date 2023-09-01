using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.DTOs.RecipeIngredientDTO;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using System.Collections.Generic;

namespace NET_Restaurant_API.Services
{
    public class RecipeIngredientService
    {
        public RecipeIngredientRepository _recipeIngredientRepository;
        public IMapper _mapper;
        public RecipeIngredientService(RecipeIngredientRepository recipeIngredientRepository, IMapper mapper)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeIngredientDTO>> GetAll()
        {
            List<RecipeIngredient> recipeIngredients = await _recipeIngredientRepository.GetAll();
            List<RecipeIngredientDTO> recipeIngredientsDTO = _mapper.Map<List<RecipeIngredientDTO>>(recipeIngredients);

            return recipeIngredientsDTO;
        }

        public RecipeIngredientDTO Create(RecipeIngredientDTO recipeIngredientDTO)
        {
            RecipeIngredient recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientDTO);
            _recipeIngredientRepository.Create(recipeIngredient);
            _recipeIngredientRepository.Save();
            //            _restaurantRepository.Save();
            //System.Diagnostics.Debug.WriteLine(restaurant);

            return recipeIngredientDTO;
        }
    }
}
