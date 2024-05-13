using Microsoft.AspNetCore.Identity;

namespace Mongo.Services.Auth.Models;

public class ApplicationUser :IdentityUser
{
    public string? Name { get; set; }
}