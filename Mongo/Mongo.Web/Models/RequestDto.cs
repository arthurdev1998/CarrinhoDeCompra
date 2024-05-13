using Mongo.Web.Enums;
using System.Net.Mime;

namespace Mongo.Web.Models;

public class RequestDto
{
    public ApiTypes ApiType { get; set; } = ApiTypes.GET;
    public required string UrL { get; set; }
    public object? Data { get; set; }
    public string? AcessToken { get; set; }

    public ContentType ContentType { get; set; }
}   