
using Mongo.Services.Products.Data;

namespace Mongo.Services.Products.Security;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;    
    }

    public async Task<bool> Commit()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public void Dispose() => _db.Dispose();
}