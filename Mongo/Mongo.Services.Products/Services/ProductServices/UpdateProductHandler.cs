using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Mappers.ProductMappers;
using Mongo.Services.Products.Messages;
using Mongo.Services.Products.Models;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Security;

namespace Mongo.Services.Products.Services.ProductServices;

public class UpdateProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;  
    }

    public async Task<ServiceResult<ProductDto>> ExecuteAsync(UpdateDto dto)
    {
        var entity = await _productRepository.GetByIdProduct(dto.Id);

        if(entity == null)
            return new ServiceResult<ProductDto>("Produto nao encontrado");
        
        dto.MapOver(entity);
        await _unitOfWork.Commit();

        var result = entity.MapTo<ProductDto>();

        return new ServiceResult<ProductDto>(result);
    }
}