namespace Mongo.Services.Products.Security;

public interface IUnitOfWork : IDisposable
{
    public Task<bool> Commit();
}