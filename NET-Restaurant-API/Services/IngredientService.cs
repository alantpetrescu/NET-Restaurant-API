using AutoMapper;
using NET_Restaurant_API.Models.DTOs.IngredientDTO;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Models.DTOs.RecipeDTO;

namespace NET_Ingredient_API.Services
{
    public class IngredientService
    {
        public IngredientRepository _ingredientRepository;
        public IMapper _mapper;
        public IngredientService(IngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public IngredientResponseDTO GetIngredient(Guid IngredientId)
        {
            Ingredient ingredient = _ingredientRepository.Get(IngredientId);
            IngredientResponseDTO IngredientResponseDTO = _mapper.Map<IngredientResponseDTO>(ingredient);

            return IngredientResponseDTO;
        }

        public async Task<List<IngredientResponseDTO>> GetAll()
        {
            List<Ingredient> ingredients = await _ingredientRepository.GetAll();
            List<IngredientResponseDTO> ingredientsResponseDTO = _mapper.Map<List<IngredientResponseDTO>>(ingredients);

            return ingredientsResponseDTO;
        }

        public List<RecipeResponseDTO> GetRecipesContainingIngredient(String ingredientName)
        {
            var recipeResponseDTO =  _mapper.Map<List<RecipeResponseDTO>>(_ingredientRepository.GetRecipesContainingIngredient(ingredientName));

            return recipeResponseDTO;
        }

        public IngredientResponseDTO Create(IngredientCreateDTO ingredientCreateDTO)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(ingredientCreateDTO);
            //            System.Diagnostics.Debug.WriteLine(ingredient);

            _ingredientRepository.Create(ingredient);
            _ingredientRepository.Save();
            //            _ingredientRepository.Save();
            //System.Diagnostics.Debug.WriteLine(ingredient);

            IngredientResponseDTO ingredientResponseDTO = _mapper.Map<IngredientResponseDTO>(ingredient);
            return ingredientResponseDTO;
        }

        public IngredientResponseDTO Update(Guid ingredientId, IngredientCreateDTO ingredientCreateDTO)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(ingredientCreateDTO);
            ingredient.Id = ingredientId;

            _ingredientRepository.Update(ingredient);
            _ingredientRepository.Save();
            //            _ingredientRepository.Save();
            //System.Diagnostics.Debug.WriteLine(ingredient);

            IngredientResponseDTO ingredientResponseDTO = _mapper.Map<IngredientResponseDTO>(ingredient);
            return ingredientResponseDTO;
        }

        public async Task Delete(Guid ingredientId)
        {
            var ingredientToDelete = await _ingredientRepository.FindByIdAsync(ingredientId);
            _ingredientRepository.Delete(ingredientToDelete);
            await _ingredientRepository.SaveAsync();
        }
    }
}
