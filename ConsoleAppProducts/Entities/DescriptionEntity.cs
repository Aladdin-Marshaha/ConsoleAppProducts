using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProducts.Entities;

internal class DescriptionEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Ingress { get; set; } = null!;
    
    [Required]
    public string Description { get; set; } = null!;
    public string? Specifications { get; set; }
}
