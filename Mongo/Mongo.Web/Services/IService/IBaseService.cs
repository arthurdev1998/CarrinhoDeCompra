using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface IBaseService<T>
{
    Task<ServiceResult<T?>> SendAsync(RequestDto requestDto);
}