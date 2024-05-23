using Mongo.Services.Products.Data.Repositories;
using Mongo.Services.Products.Messages;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Security;

namespace Mongo.Services.Products.Services.ProductServices;

public class RemoveProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductHandler(IProductRepository productRepository,  IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult> ExecuteAsync(int id)
    {
        var entity = await 
        _productRepository.GetByIdProduct(id);

        if(entity == null)
            return new ServiceResult<ProductDto>("ProductNotFound");
        
        await _productRepository.RemoveProduct(entity);
        await _unitOfWork.Commit();

        return new ServiceResult();
    }   
}