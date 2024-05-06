namespace Mongo.Web.Messages;

public class ServiceResult<T> : ServiceResult
{
    public T? Result { get; set; }
    public List<T>? Results {get; set;}

    public ServiceResult(string message) : base(message)
    { 
        
    }

    public ServiceResult(T value)
    {
        Result = value;
    }

    public ServiceResult(List<T> values)
    {
        Results = values;
    }

    public ServiceResult()
    {

    }
}

public class ServiceResult 
{   
    public ICollection<string> ErrorMessages { get; set; } = [];
    public bool HasError { get; set; } = false;

    public ServiceResult(string message)
    {
        HasError = true;
        ErrorMessages.Add(message);
    }

    public ServiceResult()
    {
    }
}