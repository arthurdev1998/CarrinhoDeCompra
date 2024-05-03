using Microsoft.EntityFrameworkCore;
using Mongo.Services.CupomApi.Entities;

namespace Mongo.Services.CupomApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cupom> Cupoms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cupom>().HasData(new Cupom
        {
            Id = 1,
            Code = "50Off",
            DiscountAmount = 50,
            MinAmount = 100
        },
        new Cupom
        {

            Id = 2,
            Code = "20Off",
            DiscountAmount = 20,
            MinAmount = 100
        });
    }
}