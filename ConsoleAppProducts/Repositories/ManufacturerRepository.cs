using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Entities;

namespace ConsoleAppProducts.Repositories;

internal class ManufacturerRepository : GenericRepo<ManufacturerEntity>
{
    public ManufacturerRepository(DataContext context) : base(context)
    {
    }
}


