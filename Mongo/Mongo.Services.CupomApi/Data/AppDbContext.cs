using Microsoft.EntityFrameworkCore;
using Mongo.Services.CupomApi.Entities;

namespace Mongo.Services.CupomApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
    }

    public DbSet<Cupom> Cupoms { get; set; }
}