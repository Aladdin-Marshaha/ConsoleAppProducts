using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppProducts.Entities;

internal class ProductEntity
{
    [Key]
    [Column(TypeName = "nvarchar(50)")]
    public string ArticleNumber {  get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = null!;


    public int ManufacturerId { get; set; }
    public ManufacturerEntity Manufacturer { get; set; } = null!;

    public int DescriptionId { get; set; }
    public DescriptionEntity Description { get; set; } = null!;

    public int PriceListId { get; set; }
    public PriceListEntity PriceList { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
