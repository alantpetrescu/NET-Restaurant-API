using System.ComponentModel.DataAnnotations;

namespace NET_Restaurant_API.Models.DTOs.UserDTO
{
    public class UserAuthRequestDTO
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
