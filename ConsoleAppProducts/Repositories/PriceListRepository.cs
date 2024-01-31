using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Entities;

namespace ConsoleAppProducts.Repositories;

internal class PriceListRepository : GenericRepo<PriceListEntity>
{
    public PriceListRepository(DataContext context) : base(context)
    {
    }
}


