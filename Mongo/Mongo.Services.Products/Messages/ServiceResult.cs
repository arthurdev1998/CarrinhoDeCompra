namespace Mongo.Services.Products.Messages;

public class ServiceResult<T> : ServiceResult where T : class
{

    public T? Result { get; set; }
    public List<T>? Results { get; set; }

    public ServiceResult(string message) : base(message)
    {

    }

    public ServiceResult(T value) : base(value)
    {
        Result = value;
    }

    public ServiceResult(List<T> values) : base(values)
    {
        Results = values;
    }

    public ServiceResult()
    {

    }
}

public class ServiceResult
{
    public object? Resultado { get; set; }
    public ICollection<string> ErrorMessages { get; set; } = [];
    public bool HasError { get; set; } = false;

    public ServiceResult(string message)
    {
        HasError = true;
        ErrorMessages.Add(message);
    }

    public ServiceResult(object obj)
    {
        Resultado = obj;
    }

    public ServiceResult()
    {
    }
}