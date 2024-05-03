namespace Mongo.Services.CupomApi.Dtos;

public class CupomDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}