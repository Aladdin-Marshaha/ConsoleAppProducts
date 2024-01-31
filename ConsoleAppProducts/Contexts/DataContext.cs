using ConsoleAppProducts.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppProducts.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<DescriptionEntity> Desctiptions { get; set;}
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    public DbSet<PriceListEntity> Prices { get; set; }
    public DbSet<ProductEntity> Products { get; set;}
}
