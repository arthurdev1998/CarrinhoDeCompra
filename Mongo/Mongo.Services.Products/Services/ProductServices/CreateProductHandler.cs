using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Mappers.ProductMappers;
using Mongo.Services.Products.Messages;
using Mongo.Services.Products.Models;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Security;

namespace Mongo.Services.Products.Services.ProductServices;

public class CreateProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;

    public CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, HttpContext httpContext)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContext;
    }

    public async ValueTask<ServiceResult<ProductDto>> ExecuteAsync(ProductInsertDto dto)
    {
        var entity = dto.MapToNew();
        //aplicar validatiosn

        if (entity.ImageUrl != null)
        {
            string fileName = entity.Id + Path.GetExtension(dto.Image.FileName);
            string filePath = @"wwwroot\ProductImages\" + fileName;

            //I have added the if condition to remove the any image with same name if that exist in the folder by any change
            var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            FileInfo file = new FileInfo(directoryLocation);
            if (file.Exists)
            {
                file.Delete();
            }

            var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            var baseUrl = $"{_httpContext.Request.Scheme}://{_httpContext.Request.Host.Value}{_httpContext.Request.PathBase.Value}";
            entity.ImageUrl = baseUrl + "/ProductImages/" + fileName;
            entity.ImageLocalPath = filePath;
        }
        else
        {
            entity.ImageUrl = "https://placehold.co/600x400";
        }

        await _productRepository.CreateProduct(entity);

        if(await _unitOfWork.Commit())
            return new ServiceResult<ProductDto>(entity.MapTo<ProductDto>());
        
        return new ServiceResult<ProductDto>("erro ao salvar o arquivo");
    }
}