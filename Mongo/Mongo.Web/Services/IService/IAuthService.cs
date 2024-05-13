using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface IAuthService
{
    Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
    Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
    Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
}