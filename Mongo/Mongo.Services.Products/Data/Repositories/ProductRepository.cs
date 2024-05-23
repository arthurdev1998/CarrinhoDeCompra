using Microsoft.EntityFrameworkCore;
using Mongo.Services.Products.Models;

namespace Mongo.Services.Products.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Product> CreateProduct(Product obj)
    {
       await _db.Products.AddAsync(obj);
       return obj;
    }

    public async Task<ICollection<Product>> GetAllProducts()
    {
        return await _db.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetByIdProduct(int id)
    {
        var entity = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public void RemoveProduct(Product obj)
    {
        _db.Products.Remove(obj);
    }

    public Task<Product> UpdateProduct(Product obj)
    {
        _db.Products.Update(obj);
        return Task.FromResult(obj);
    }
}