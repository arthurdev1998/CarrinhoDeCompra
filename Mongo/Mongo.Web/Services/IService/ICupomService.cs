using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface ICupomService
{
    Task<ResponseDto?> GetAllCupomAsync();
    Task<ResponseDto?> GetCupomByCodeAsync(string code);
    Task<ResponseDto?> GetCupomByIdAsync(int id);
    Task<ResponseDto?> InsertCupomAsync(CupomDto dto);
    Task<ResponseDto?> RemoveCupomAsync(int id);
    Task<ResponseDto?> UpdateCupomAsync(CupomDto dto);
}