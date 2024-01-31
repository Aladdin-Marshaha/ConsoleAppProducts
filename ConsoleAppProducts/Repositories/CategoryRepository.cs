using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Entities;

namespace ConsoleAppProducts.Repositories;

internal class CategoryRepository : GenericRepo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}


