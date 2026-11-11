using betterboxd_web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace betterboxd_web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
    {
    private readonly UserManager<IdentityUser> _userManager;
    public UsersController(UserManager<IdentityUser> userManager)
        => _userManager = userManager;

    public record RegisterDto(string Username, string Email, string Password);
    public record LoginDto(string Email, string Password);

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new IdentityUser { UserName = dto.Username, Email = dto.Email };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.Select(e => e.Description));
        }
        return Ok(new { user.Id, user.UserName, user.Email });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email) ?? await _userManager.FindByNameAsync(dto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            return Unauthorized("E-posta veya şifre hatalı");

        return Ok(new { user.Id, user.UserName, user.Email });
    }

}

