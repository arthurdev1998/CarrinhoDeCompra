#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.Auth.Data;
using Mongo.Services.Auth.Mappers.UserMappers;
using Mongo.Services.Auth.Models;
using Mongo.Services.Auth.Services.IService;

namespace Mongo.Services.Auth.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenGenerator _jwt;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(AppDbContext context, IJwtTokenGenerator jwt,
    UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _jwt = jwt;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> AssignRole(string email, string roleName)
    {
        var user = _context.ApplicationUsers.FirstOrDefault(x => x.Email.ToLower() == email);
        if (user != default)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new IdentityRole(roleName));

            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }

        return false;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == loginRequestDto.UserName);
        var isValidPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

        if (user == null || isValidPassword == false)
        {
            return LoginResponseDto.Create(null, null);
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwt.GenerateToken(user, roles);

        var userDto = UserDto.Create()
        .WithId(user.Id)
        .WithPhoneNumber(user.PhoneNumber)
        .WithEmail(user.NormalizedEmail)
        .WithName(user.Name)
        .Build();

        return LoginResponseDto.Create(userDto, token);
    }

    // REGISTRO DE USUARIO SEM UMA ROLE
    public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
    {
        var user = registrationRequestDto.MapToNew();

        var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

        if (result.Succeeded)
        {
            var userToReturn = _context.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDto.Email);

            var userDto = UserDto.Create()
            .WithId(userToReturn.Id)
            .WithPhoneNumber(userToReturn.PhoneNumber)
            .WithEmail(userToReturn.NormalizedEmail)
            .WithName(userToReturn.Name)
            .Build();

            return userDto.ToString();
        }
        else
        {
            return result.Errors.FirstOrDefault().Description;
        }
    }
}