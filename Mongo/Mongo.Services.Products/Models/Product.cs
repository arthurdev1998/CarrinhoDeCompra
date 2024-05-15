using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mongo.Services.Products.Models;

[Table("produto")]
public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageLocalPath { get; set; }
}