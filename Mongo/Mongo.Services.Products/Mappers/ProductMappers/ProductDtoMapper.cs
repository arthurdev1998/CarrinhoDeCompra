using Mongo.Services.Products.Models;
using Mongo.Services.Products.Models.Dtos;

namespace Mongo.Services.Products.Mappers.ProductMappers;

public static class ProductDtoMapper
{
    public static ProductDto MapToProductDto(this Product src)
    {
        return new ProductDto
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price,
            Description = src.Description,
            Category = src.Category,
            ImageUrl = src.ImageUrl
        };
    }

    public static List<ProductDto> MapToProductDto(this ICollection<Product> src)
    {
        return src.Select(x => MapToProductDto(x)).ToList();
    }

    public static void MapOver(this UpdateDto dto, Product product)
    {
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Description = dto.Description;
        product.Category = dto.Category;
    }
}