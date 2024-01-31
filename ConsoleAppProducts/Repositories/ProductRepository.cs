using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleAppProducts.Repositories;

internal class ProductRepository : GenericRepo<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ProductEntity Get(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products
            .Include(i => i.Manufacturer)
            .Include(i => i.Category)
            .Include(i => i.PriceList)
            .Include(i => i.Description)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products
            .Include(i => i.Manufacturer)
            .Include(i => i.Category)
            .Include(i => i.PriceList)
            .Include(i => i.Description)
            .ToList();
    }
}
