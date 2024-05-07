using Mongo.Web.Enums;
using Mongo.Web.Messages;
using Mongo.Web.Models;
using Mongo.Web.Services.IService;

namespace Mongo.Web.Services;

public class CupomService : ICupomService
{
    private readonly IBaseService _baseService;

    public CupomService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto?> GetAllCupomAsync()
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.GET,
            UrL = Sd.CupomApiBaseUrl + "/api/cupom"
        });

        return result;
    }

    public async Task<ResponseDto?> GetCupomByCodeAsync(string code)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.GET,
            UrL = Sd.CupomApiBaseUrl + $"/api/cupom/GetByCode/{code}"
        });

        return result;
    }

    public async Task<ResponseDto?> GetCupomByIdAsync(int id)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.GET,
            UrL = Sd.CupomApiBaseUrl + $"/api/cupom/{id}"
        });

        return result;
    }

    public async Task<ResponseDto?> InsertCupomAsync(CupomDto dto)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.POST,
            Data = dto,
            UrL = Sd.CupomApiBaseUrl + $"/api/cupom"
        });

        return result;
    }

    public async Task<ResponseDto?> RemoveCupomAsync(int id)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.DELETE,
            UrL = Sd.CupomApiBaseUrl + $"/api/cupom/{id}"
        });

        return result;
    }

    public async Task<ResponseDto?> UpdateCupomAsync(CupomDto dto)
    {
        var result = await _baseService.SendAsync(new RequestDto()
        {
            ApiType = ApiTypes.PUT,
            Data = dto,
            UrL = Sd.CupomApiBaseUrl + $"/api/cupom"
        });

        return result;
    }
}