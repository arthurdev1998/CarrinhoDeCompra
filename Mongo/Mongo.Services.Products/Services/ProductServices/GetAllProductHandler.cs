using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Mappers.ProductMappers;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Security;

namespace Mongo.Services.Products.Services.ProductServices;

public class GetAllProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ProductDto>?> ExecuteAsync()
    {
        var result = await _productRepository.GetAllProducts();
        return result?.MapTo<List<ProductDto>>();
    }
}