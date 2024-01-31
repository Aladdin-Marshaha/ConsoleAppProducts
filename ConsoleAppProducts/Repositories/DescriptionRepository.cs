using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Entities;

namespace ConsoleAppProducts.Repositories;

internal class DescriptionRepository : GenericRepo<DescriptionEntity>
{
    public DescriptionRepository(DataContext context) : base(context)
    {
    }
}


