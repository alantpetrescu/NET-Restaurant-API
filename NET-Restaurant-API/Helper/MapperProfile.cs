using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.DTOs.IngredientDTO;
using NET_Restaurant_API.Models.DTOs.RecipeDTO;
using NET_Restaurant_API.Models.DTOs.RecipeIngredientDTO;
using NET_Restaurant_API.Models.DTOs.UserDTO;

namespace NET_Restaurant_API.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeCreateDTO>();
            CreateMap<Employee, EmployeeResponseDTO>();
            CreateMap<Manager, ManagerCreateDTO>();
            CreateMap<Manager, ManagerResponseDTO>();
            CreateMap<Recipe, RecipeCreateDTO>();
            CreateMap<Recipe, RecipeResponseDTO>();
            CreateMap<Restaurant, RestaurantCreateDTO>();
            CreateMap<Restaurant, RestaurantResponseDTO>();
            CreateMap<User, UserAuthRequestDTO>();
            CreateMap<User, UserAuthResponseDTO>();
            CreateMap<Ingredient, IngredientCreateDTO>();
            CreateMap<Ingredient, IngredientResponseDTO>();
            CreateMap<RecipeIngredient, RecipeIngredientDTO>();


            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeResponseDTO, Employee>();
            CreateMap<ManagerCreateDTO, Manager>();
            CreateMap<ManagerResponseDTO, Manager>();
            CreateMap<RecipeCreateDTO, Recipe>();
            CreateMap<RecipeResponseDTO, Recipe>();
            CreateMap<RestaurantCreateDTO, Restaurant>();
            CreateMap<RestaurantResponseDTO, Restaurant>();
            CreateMap<UserAuthRequestDTO, User>();
            CreateMap<UserAuthResponseDTO, User>();
            CreateMap<IngredientCreateDTO, Ingredient>();
            CreateMap<IngredientResponseDTO, Ingredient>();
            CreateMap<RecipeIngredientDTO, RecipeIngredient>();
        }

    }
}
