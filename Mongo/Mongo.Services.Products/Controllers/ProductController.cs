using Microsoft.AspNetCore.Mvc;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Services.ProductServices;

namespace Mongo.Services.Products.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : Controller
{
    private readonly CreateProductHandler _createProductHandler;

    public ProductController(CreateProductHandler createProductHandler)
    {
        _createProductHandler = createProductHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductInsertDto productInsertDto)
    {
        var result = await _createProductHandler.ExecuteAsync(productInsertDto);

        if(!result.HasError)
        {
            return Ok(result.Result);
        }

        return BadRequest(result.ErrorMessages);
    }
}