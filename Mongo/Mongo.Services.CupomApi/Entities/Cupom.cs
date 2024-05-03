namespace Mongo.Services.CupomApi.Entities;

public class Cupom
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
       
}