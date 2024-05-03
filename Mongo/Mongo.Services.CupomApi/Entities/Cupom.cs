using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mongo.Services.CupomApi.Entities;

[Table("cupom")]
public class Cupom
{
    [Key]
    public int Id { get; set; }

    [Column("code"),Required]
    public string? Code { get; set; }

    [Column("discount")]
    public double DiscountAmount { get; set; }

    [Column("min_amount")]
    public int MinAmount { get; set; }
}