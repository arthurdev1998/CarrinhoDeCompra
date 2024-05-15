using Mongo.Services.Products.Models;
using Mongo.Services.Products.Models.Dtos;

namespace Mongo.Services.Products.Mappers.ProductMappers;

public static class ProductMapperExtension
{
    public static T MapTo<T>(this Product src)
    {
        var product = new List<Product> { src };

        return product.MapTo<ICollection<T>>().First();
    }

    public static T MapTo<T>(this ICollection<Product> src)
    {
        var typeOfSrcInterfaces = typeof(T).GetInterfaces();

        if (typeOfSrcInterfaces.Any(x => x == typeof(ICollection<ProductDto>)))
        {
            return (T)(object)ProductDtoMapper.MapToProductDto(src);
        }

        throw new ArgumentException($"{typeof(T)} nao implementado");
    }

    public static Product MapToNew(this ProductInsertDto dto)
    {
        return new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            Category = dto.CategoryName,
            ImageUrl = dto.ImageUrl,
            ImageLocalPath = dto.ImageLocalPath
        };
    }
}