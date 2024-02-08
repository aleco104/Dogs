using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;

namespace ClassLibrary1.ProductRepositories;

public class TargetAnimalRepository(ProductContext context) : ProductRepo<TargetAnimal>(context)
{
    private readonly ProductContext _context = context;
}
