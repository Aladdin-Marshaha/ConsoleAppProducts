using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppProducts.Entities;

internal class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductEntity> Products = new List<ProductEntity>();
}
