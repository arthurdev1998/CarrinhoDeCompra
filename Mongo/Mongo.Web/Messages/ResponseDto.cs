namespace Mongo.Web.Messages;

public class ResponseDto
{
    public object? Result { get; set; }
    public bool HasError { get; set; } = false;
    public string? MessageError { get; set; }   
}