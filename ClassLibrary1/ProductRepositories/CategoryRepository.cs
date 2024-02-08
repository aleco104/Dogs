using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;

namespace ClassLibrary1.ProductRepositories;

public class CategoryRepository(ProductContext context) : ProductRepo<Category>(context)
{
    private readonly ProductContext _context = context;
}
