using System.Net;
using System.Text;
using Mongo.Web.Messages;
using Mongo.Web.Models;
using Mongo.Web.Services.IService;
using Newtonsoft.Json;

namespace Mongo.Web.Services;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ServiceResult> SendAsync<T>(RequestDto requestDto)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient("CarrinhoApi");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            //token

            message.RequestUri = new Uri(requestDto.UrL);

            if (requestDto.Data != null)
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");

            switch (requestDto.ApiType)
            {
                case Enums.ApiTypes.GET:
                    message.Method = HttpMethod.Get;
                    break;

                case Enums.ApiTypes.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case Enums.ApiTypes.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                case Enums.ApiTypes.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                default: return new ServiceResult($"{nameof(requestDto.ApiType)} invalido");
            }

            HttpResponseMessage? apiResponse;
            apiResponse = await client.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ServiceResult(nameof(HttpStatusCode.NotFound));

                case HttpStatusCode.Forbidden:
                    return new ServiceResult(nameof(HttpStatusCode.Forbidden));

                case HttpStatusCode.Unauthorized:
                    return new ServiceResult(nameof(HttpStatusCode.Unauthorized));

                case HttpStatusCode.InternalServerError:
                    return new ServiceResult(nameof(HttpStatusCode.InternalServerError));

                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    if (apiContent.StartsWith("["))
                    {
                        var apiListResponseDto = JsonConvert.DeserializeObject<List<T>>(apiContent) ?? throw new NullReferenceException(nameof(JsonConvert));

                        return new ServiceResult<T>(apiListResponseDto);
                    }

                    var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent) ?? throw new NullReferenceException(nameof(JsonConvert));

                    return new ServiceResult<T>(apiResponseDto);

            }
        }
        catch (Exception ex)
        {
            return new ServiceResult(ex.Message);
        }
    }
}