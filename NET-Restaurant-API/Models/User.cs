using NET_Restaurant_API.Models.Enums;
using NET_Restaurant_API.Models.Base;
using System.Text.Json.Serialization;

namespace NET_Restaurant_API.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;

        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
