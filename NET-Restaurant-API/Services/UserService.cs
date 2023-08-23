using AutoMapper;
using NET_Restaurant_API.Helpers.Jwt;
using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.DTOs.UserDTO;
using NET_Restaurant_API.Repositories.DatabaseRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace NET_Restaurant_API.Services
{
    public class UserService
    {
        public UserRepository _userRepository;
        public IJwtUtils _jwtUtilis;
        public IMapper _mapper;

        public UserService(UserRepository userRepository, IJwtUtils jwtUtilis, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtUtilis = jwtUtilis;
            _mapper = mapper;
        }

        public UserAuthResponseDTO Authentificate(UserAuthRequestDTO model)
        {
            var teacher = _userRepository.FindByEmail(model.Email);
            if (teacher == null || !BCryptNet.Verify(model.Password, teacher.PasswordHash))
            {
                return null; // or throw exception
            }

            // jwt generation
            var jwtToken = _jwtUtilis.GenerateJwtToken(teacher);
            return new UserAuthResponseDTO(teacher, jwtToken);
        }

        public async Task Create(UserAuthRequestDTO teacher)
        {
            var newDBUser = _mapper.Map<User>(teacher);
            newDBUser.PasswordHash = BCryptNet.HashPassword(teacher.Password);
            newDBUser.Role = Role.User;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public async Task<List<User>> GetAllTeachers()
        {
            return await _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }
    }
}
