namespace Mongo.Services.Auth.Models;

public class LoginResponseDto
{
    public UserDto? User { get; set; }
    public string? Token { get; set; }

    public static LoginResponseDto Create(UserDto? userDto, string? token)
    {
        return new LoginResponseDto()
        {
            User = userDto,
            Token = token
        };
    }

    private LoginResponseDto()
    {

    }
}