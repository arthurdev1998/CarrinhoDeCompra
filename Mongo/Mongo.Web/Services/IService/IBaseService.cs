using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface IBaseService
{
    Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
}