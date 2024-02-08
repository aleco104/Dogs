using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;

namespace ClassLibrary1.ProductRepositories;

public class ManufacturerRepository(ProductContext context) : ProductRepo<Manufacturer>(context)
{
    private readonly ProductContext _context = context;
}
