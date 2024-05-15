using Mongo.Services.Products.Models;

namespace Mongo.Services.Products.Data.Repositories;

public interface IProductRepository
{
    public Task<ICollection<Product>> GetAllProducts();
    public Task<Product> UpdateProduct(Product obj);
    public Task<Product> CreateProduct(Product obj);
    public Task<Product> GetByIdProduct(int id);
    public void RemoveProduct(Product obj);
}
