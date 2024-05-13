using Mongo.Services.Auth.Models;

namespace Mongo.Services.Auth.Mappers.UserMappers;

public static class UserMapperExtension
{
    // public static T MapTo<T>(this xuxu src)
    // {
    //     var paises = new List<xuxu> { src };

    //     return paises.MapTo<IList<T>>().First();
    // }

    public static ApplicationUser MapToNew(this RegistrationRequestDto registrationRequestDto)
    {
        if(registrationRequestDto.Email == null)
        throw new ArgumentNullException($"Null Argument {nameof(registrationRequestDto.Email)}");

        return new ApplicationUser()
        {
            UserName = registrationRequestDto.Email,
            Email = registrationRequestDto.Email,
            NormalizedEmail = registrationRequestDto.Email.ToUpper(),
            Name = registrationRequestDto.Name,
            PhoneNumber = registrationRequestDto.PhoneNumber
        };
    }
}