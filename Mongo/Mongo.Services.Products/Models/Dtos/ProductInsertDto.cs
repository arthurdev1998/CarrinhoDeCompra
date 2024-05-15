namespace Mongo.Services.Products.Models.Dtos;

public class ProductInsertDto
{
    public int ProductId { get; init; }
    public string? Name { get; init; }
    public double? Price { get; init; }
    public string? Description { get; init; }
    public string? CategoryName { get; init; }
    public string? ImageUrl { get; init; }
    public string? ImageLocalPath { get; init; }
    public IFormFile? Image { get; init; }
}