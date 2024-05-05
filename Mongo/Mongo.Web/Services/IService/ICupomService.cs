using Mongo.Web.Messages;
using Mongo.Web.Models;

namespace Mongo.Web.Services.IService;

public interface ICupomService
{
    Task<ServiceResult?> GetAllCupomAsync();
    Task<ServiceResult>? GetCupomByCodeAsync(string code);
    Task<ServiceResult>? GetCupomByIdAsync(int id);
    Task<ServiceResult>? InsertCupomAsync(CupomDto dto);
    Task<ServiceResult>? RemoveCupomAsync(int id);
    Task<ServiceResult>? UpdateCupomAsync(CupomDto dto);
}