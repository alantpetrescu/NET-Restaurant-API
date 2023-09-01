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
            var user = _userRepository.FindByEmail(model.Email);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; // or throw exception
            }

            // jwt generation
            var jwtToken = _jwtUtilis.GenerateJwtToken(user);
            return new UserAuthResponseDTO(user, jwtToken);
        }

        public async Task CreateUser(UserAuthRequestDTO user)
        {
            var newDBUser = _mapper.Map<User>(user);
            newDBUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            newDBUser.Role = Role.User;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public async Task CreateAdmin(UserAuthRequestDTO user)
        {
            var newDBUser = _mapper.Map<User>(user);
            newDBUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            newDBUser.Role = Role.Admin;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public async Task Update(Guid userId, UserAuthRequestDTO user)
        {
            var dbUser = _mapper.Map<User>(user);
            dbUser.Id = userId;
            dbUser.PasswordHash = BCryptNet.HashPassword(user.Password);
            dbUser.Role = Role.User;
            //dbUser.DateModified = DateTime.UtcNow;

            _userRepository.Update(dbUser);
            await _userRepository.SaveAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task Delete(Guid restaurantId)
        {
            var restaurantToDelete = await _userRepository.FindByIdAsync(restaurantId);
            _userRepository.Delete(restaurantToDelete);
            await _userRepository.SaveAsync();
        }
    }
}
