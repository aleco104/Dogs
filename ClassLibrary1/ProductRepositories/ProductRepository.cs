using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ClassLibrary1.ProductRepositories;

public class ProductRepository(ProductContext context) : ProductRepo<Product>(context)
{
    private readonly ProductContext _context = context;

    public override IEnumerable<Product> GetAll()
    {
        try
        {
            return _context.Products
                .Include(x => x.Animal)
                .Include(x => x.Category)
                .Include(x => x.Manufacturer)
                .ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public override Product GetOne(Expression<Func<Product, bool>> predicate)
    {
        try
        {
            return _context.Products
                .Include(x => x.Animal)
                .Include(x => x.Category)
                .Include(x => x.Manufacturer)
                .FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }
}
