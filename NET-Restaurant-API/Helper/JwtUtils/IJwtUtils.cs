using NET_Restaurant_API.Models;

namespace NET_Restaurant_API.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
