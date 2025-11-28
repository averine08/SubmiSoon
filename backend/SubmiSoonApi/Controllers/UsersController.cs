using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Data;

namespace SubmiSoonApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub) ?? 
                            User.FindFirst(ClaimTypes.NameIdentifier);
            
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Invalid token" });
            }

            int userId = int.Parse(userIdClaim.Value);

            var user = await _db.Students.FirstOrDefaultAsync(s => s.StudentId == userId);
            if (user == null) return NotFound();

            return Ok(new
            {
                user.StudentId,
                user.Name,
                user.Email
            });
        }
    }

}