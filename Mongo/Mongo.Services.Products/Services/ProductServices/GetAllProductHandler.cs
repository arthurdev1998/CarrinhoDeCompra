using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Mappers.ProductMappers;
using Mongo.Services.Products.Messages;
using Mongo.Services.Products.Models.Dtos;

namespace Mongo.Services.Products.Services.ProductServices;

public class GetAllProductHandler
{
    private readonly IProductRepository _productRepository;

    public GetAllProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ServiceResult<List<ProductDto>>> ExecuteAsync()
    {
        var products = await _productRepository.GetAllProducts();

        if(products == null)
            return new ServiceResult<List<ProductDto>>();
        
        var result = products.MapTo<List<ProductDto>>();

        return new ServiceResult<List<ProductDto>>(result);
    }
}