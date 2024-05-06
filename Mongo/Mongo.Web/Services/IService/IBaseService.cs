using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface IBaseService
{
    Task<ServiceResult> SendAsync<T>(RequestDto requestDto);
}