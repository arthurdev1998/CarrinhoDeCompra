using Microsoft.AspNetCore.Mvc;
using Mongo.Services.Auth.Models;
using Mongo.Services.Auth.Services.IService;

namespace Mongo.Services.Auth.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
    {
        var result = await _authService.Register(model);

        if (string.IsNullOrEmpty(result))
        {
            return BadRequest("deu erro");
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var user = await _authService.Login(model);
        if (user == null)
            return BadRequest("usuario nao encontrado");

        return Ok(user.Token);
    }

    [HttpPost("AssignRole")]
    public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
    {
        var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
        if (!assignRoleSuccessful)
        {
            return BadRequest("nao deu");
        }

        return Ok(model.Role);

        
    }
}