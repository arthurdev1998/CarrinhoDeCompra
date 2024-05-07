namespace Mongo.Services.CupomApi.Messages;

public class ResponseDto
{
    public object? Result { get; set; }
    public bool HasError { get; set; } = false;
    public string? MessageError { get; set; }

    public ResponseDto(string errorMessage)
    {
        MessageError = errorMessage;
        HasError = true;
    }

    public ResponseDto(object result)
    {
        Result = result;
    }

    public ResponseDto()
    {
        
    }
}