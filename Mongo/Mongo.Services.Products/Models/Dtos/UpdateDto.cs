namespace Mongo.Services.Products.Models.Dtos;

public class UpdateDto
{
    public int Id {get; set;}
    public string? Name { get; set; }
    public double? Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
}