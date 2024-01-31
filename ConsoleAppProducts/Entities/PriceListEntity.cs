using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProducts.Entities;

internal class PriceListEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Precision(10,2)]
    public decimal Price { get; set; }

    [Precision(10, 2)]
    public decimal? DiscountPrice { get; set; }


}
