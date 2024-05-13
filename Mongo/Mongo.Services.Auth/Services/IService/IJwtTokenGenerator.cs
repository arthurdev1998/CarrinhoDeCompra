using Mongo.Services.Auth.Models;

namespace Mongo.Services.Auth.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
