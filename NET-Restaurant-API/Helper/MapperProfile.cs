using AutoMapper;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs;
using NET_Restaurant_API.Models.DTOs.RecipeDTO;

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

            //CreateMap<List<Employee>, List<EmployeeCreateDTO>>();
            //CreateMap<List<Employee>, List<EmployeeResponseDTO>>();
            //CreateMap<List<Manager>, List<ManagerCreateDTO>>();
            //CreateMap<List<Manager>, List<ManagerResponseDTO>>();
            //CreateMap<List<Recipe>, List<RecipeCreateDTO>>();
            //CreateMap<List<Recipe>, List<RecipeResponseDTO>>();
            //CreateMap<List<Restaurant>, List<RestaurantCreateDTO>>();
            //CreateMap<List<Recipe>, List<RecipeResponseDTO>>();

            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeResponseDTO, Employee>();
            CreateMap<ManagerCreateDTO, Manager>();
            CreateMap<ManagerResponseDTO, Manager>();
            CreateMap<RecipeCreateDTO, Recipe>();
            CreateMap<RecipeResponseDTO, Recipe>();
            CreateMap<RestaurantCreateDTO, Restaurant>();
            CreateMap<RestaurantResponseDTO, Restaurant>();

            //CreateMap<List<EmployeeCreateDTO>, List<Employee>>();
            //CreateMap<List<EmployeeResponseDTO>, List<Employee>>();
            //CreateMap<List<ManagerCreateDTO>, List<Manager>>();
            //CreateMap<List<ManagerResponseDTO>, List<Manager>>();
            //CreateMap<List<RecipeCreateDTO>, List<Recipe>>();
            //CreateMap<List<RecipeResponseDTO>, List<Recipe>>();
            //CreateMap<List<RestaurantCreateDTO>, List<Restaurant>>();
            //CreateMap<List<RecipeResponseDTO>, List<Recipe>>();
            //CreateMap<Student, StudentDto>();
            //CreateMap<Course, CourseDto>();
            //CreateMap<CourseDto, Course>();
            //CreateMap<CourseWithStudentsDto, Course>();
            //CreateMap<Course, CourseWithStudentsDto>().ForMember(
            //    dest => dest.Students,
            //    opt => opt.MapFrom(src => src.StudentsInCourses.Select(x => x.Student))
            //);

            //CreateMap<Teacher, TeacherAuthRequestDto>();
            //CreateMap<TeacherAuthRequestDto, Teacher>();
            //CreateMap<TeacherAuthResponseDto, Teacher>();
            //CreateMap<Teacher, TeacherAuthResponseDto>();

        }

    }
}
