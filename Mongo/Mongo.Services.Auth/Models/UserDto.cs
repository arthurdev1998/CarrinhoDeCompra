namespace Mongo.Services.Auth.Models;

public class UserDto
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }

    private UserDto() { }

    public static UserDto Create()
    {
        return new UserDto();
    }

    public UserDto WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public UserDto WithId(string id)
    {
        Id = id;
        return this;
    }

    public UserDto WithName(string name)
    {
        Name = name;
        return this;
    }

    public UserDto WithPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }

    public UserDto Build()
    {
        return this;
    }
}