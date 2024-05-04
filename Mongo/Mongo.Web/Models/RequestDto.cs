using Mongo.Web.Enums;

namespace Mongo.Web.Models;

public class RequestDto
{
    public ApiTypes? ApiType { get; set; } = ApiTypes.GET;
    public string? UrL { get; set; }
    public object? Data { get; set; }
    public string? AcessToken { get; set; }
}   