using NET_Restaurant_API.Helpers.Jwt;
using NET_Restaurant_API.Services;

namespace NET_Restaurant_API.Helper.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, UserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                // httpContext.Items["User"] = teacherService.GetById(userId);

                httpContext.Items["User"] = userService.GetById(userId);

            }

            await _next(httpContext);
        }
    }
}
