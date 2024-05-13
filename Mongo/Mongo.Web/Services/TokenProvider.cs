using Mongo.Web.Enums;
using Mongo.Web.Services.IService;

namespace Mongo.Web.Services;

public class TokenProvider : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAcessor;

    public TokenProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAcessor = contextAccessor;
    }

    public void ClearToken()
    {
        _contextAcessor.HttpContext?.Response.Cookies.Delete(Sd.TokenCookie);
    }

    public string? GetToken()
    {
        string? token = null;
        bool? hasToken = _contextAcessor.HttpContext?.Request.Cookies.TryGetValue(Sd.TokenCookie, out token);
        return hasToken is true ? token : null;
    }

    public void SetToken(string token)
    {
        _contextAcessor.HttpContext?.Response.Cookies.Append(Sd.TokenCookie, token);
    }
}