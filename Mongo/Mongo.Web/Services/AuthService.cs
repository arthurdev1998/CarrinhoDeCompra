using Mongo.Web.Enums;
using Mongo.Web.Messages;
using Mongo.Web.Models;
using Mongo.Web.Services.IService;

namespace Mongo.Web.Services;

public class AuthService : IAuthService
{
    private readonly IBaseService _baseService;
    
    public AuthService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.POST,
            Data = registrationRequestDto,
            UrL = Sd.AuthApiBase + "/api/auth/AssignRole"
        });
    }

    public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.POST,
            Data = loginRequestDto,
            UrL = Sd.AuthApiBase + "/api/auth/login"
        }, withBearer: false);

        return result;
    }

    public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.POST,
            Data = registrationRequestDto,
            UrL = Sd.AuthApiBase + "/api/auth/register"
        }, withBearer: false);
    }
}