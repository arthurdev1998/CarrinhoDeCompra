using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mongo.Services.Products.Models.Dtos;
using Mongo.Services.Products.Services.ProductServices;

namespace Mongo.Services.Products.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : Controller
{
    private readonly CreateProductHandler _createProductHandler;
    private readonly GetAllProductHandler _getAllProductHandler;
    private readonly UpdateProductHandler _updateProductHandler;
    private readonly RemoveProductHandler _removeProductHandler;
    private readonly GetProductByIdHandler _getProductByIdHandler;

    public ProductController(CreateProductHandler createProductHandler,
                            GetAllProductHandler getAllProductHandler,
                            UpdateProductHandler updateProductHandler,
                            RemoveProductHandler removeProductHandler,
                            GetProductByIdHandler getProductByIdHandler)
    {
        _createProductHandler = createProductHandler;
        _getAllProductHandler = getAllProductHandler;
        _getProductByIdHandler = getProductByIdHandler;
        _updateProductHandler = updateProductHandler;
        _removeProductHandler = removeProductHandler;
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateProduct(ProductInsertDto productInsertDto)
    {
        var result = await _createProductHandler.ExecuteAsync(productInsertDto);

        if (!result.HasError)
        {
            return Ok(result.Result);
        }

        return BadRequest(result.ErrorMessages);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), 200)]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _getAllProductHandler.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet("/id")]
    [Authorize(Roles = "ADMIN")]
    [ProducesResponseType(typeof(ProductDto), 200)]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _getProductByIdHandler.ExecuteAsync(id);
        if (result.HasError)
            return BadRequest(result.ErrorMessages);

        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    [ProducesResponseType(typeof(ProductDto), 200)]
    public async Task<IActionResult> UpdateProduct(UpdateDto dto)
    {
        var result = await _updateProductHandler.ExecuteAsync(dto);
        if (result.HasError)
            return BadRequest(result.ErrorMessages);

        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    [ProducesResponseType(typeof(ActionResult), 201)]
    public async Task<IActionResult> RemoveProduct(int id)
    {
        var result = await _removeProductHandler.ExecuteAsync(id);
        
        if (result.HasError)
            return BadRequest(result.ErrorMessages);

        return Ok(result);
    }
}