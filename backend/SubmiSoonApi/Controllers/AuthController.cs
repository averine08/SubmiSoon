using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Data;
using SubmiSoonApi.Dtos.Auth;
using SubmiSoonApi.Services;

namespace SubmiSoonApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(AppDbContext db, PasswordService passwordService, JwtService jwtService) : ControllerBase
    {
        private readonly AppDbContext _db = db;
        private readonly PasswordService _passwordService = passwordService;
        private readonly JwtService _jwtService = jwtService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _db.Students.FirstOrDefaultAsync( s => s.Email == request.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Email not found" });
            }

            var valid = _passwordService.Verify(request.Password, user.PasswordHash);
            if (!valid)
            {
                return Unauthorized(new { message = "Incorrect password" });
            }

            var token = _jwtService.GenerateToken(user.StudentId, user.Email);

            return Ok(new
            {
                token,
                user = new LoginResponse
                {
                    Id = user.StudentId,
                    Name = user.Name,
                    Email= user.Email,
                    Role = "Student",
                }
            });

        }
    }
}