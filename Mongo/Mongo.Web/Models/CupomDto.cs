namespace Mongo.Web.Models;

public class CupomDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}