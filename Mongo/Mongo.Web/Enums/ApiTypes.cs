namespace Mongo.Web.Enums;

public enum ApiTypes
{
    GET,
    POST,
    PUT,
    DELETE,
    PATCH
}

public static class Sd
{
    public static string? CupomApiBaseUrl { get; set; }
    public static string? AuthApiBase { get; set; }
    public const string TokenCookie = "JWTToken";
    public const string RoleAdmin = "ADMIN";
    public const string RoleCustomer = "CUSTOMER";
}