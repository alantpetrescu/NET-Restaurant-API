namespace NET_Restaurant_API.Models.DTOs.UserDTO
{
    public class UserAuthResponseDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Token { get; set; }

        public UserAuthResponseDTO(User teacher, string token)
        {
            Id = teacher.Id;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            Email = teacher.Email;
            Token = token;
        }
    }
}
