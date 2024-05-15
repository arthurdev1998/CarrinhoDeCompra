using Microsoft.EntityFrameworkCore;
using Mongo.Services.Products.Models;

namespace Mongo.Services.Products.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}