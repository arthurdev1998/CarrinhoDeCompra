using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Mappers.ProductMappers;
using Mongo.Services.Products.Messages;
using Mongo.Services.Products.Models;
using Mongo.Services.Products.Security;

namespace Mongo.Services.Products.Services.ProductServices;

public class GetProductByIdHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ServiceResult<Product>> ExecuteAsync(int id)
    {
        var result = await _productRepository.GetByIdProduct(id);

        if(result == default)
            return new ServiceResult<Product>("Product Not Found");
        
        return new ServiceResult<Product>(result.MapTo<Product>());
    }
}