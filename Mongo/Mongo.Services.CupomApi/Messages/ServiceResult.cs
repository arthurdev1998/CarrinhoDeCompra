// namespace Mongo.Services.CupomApi.Messages;

// public class ServiceResult<T> : ServiceResult
// {
//     public ServiceResult(T data)
//     {
//         Data = data;
//     }
//     public T? Data { get; set; }

//     public ServiceResult(string message) : base(message)
//     {
//         HasError = true;
//     }
// }

// public class ServiceResult
// {
//     public bool HasError { get; set; } = false;
//     public object? Result { get; set; }
//     public ICollection<string> ErrorMessages { get; set; } = [];
//     public ServiceResult(string message) => ErrorMessages.Add(message);

//     public ServiceResult(object result)
//     {
//         Result = result;
//     }

//     public ServiceResult()
//     {
//     }
// }