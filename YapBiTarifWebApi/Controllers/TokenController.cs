using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace YapBiTarifWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    public IConfiguration _configuration;
    private readonly DataContext _context;

    public TokenController(IConfiguration config, DataContext context)
    {
        _configuration = config;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserModel _userData)
    {
        if (_userData != null && _userData.Email != null && _userData.Password != null)
        {
            var user = await GetUser(_userData.Email, _userData.Password);

            if (user != null)
            {
                //create claims details based on the user information
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.Username),
                    new Claim("Email", user.Email)
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                );
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest();
        }
    }

    private async Task<UserModel> GetUser(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(
            u => u.Email == email && u.Password == password
        );
    }
}
