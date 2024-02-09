using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
 
namespace ClassLibrary1.Repositories;

public class DogRepository(DataContext context) : Repo<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<ProductEntity> GetAll()
    {
        try
        {
            return _context.Dogs
                .Include(x => x.Color)
                .Include(x => x.Breed)
                .Include(x => x.Owner)
                .Include(x => x.Kennel)
                .ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return _context.Dogs
                .Include(x => x.Color)
                .Include(x => x.Breed)
                .Include(x => x.Owner)
                .Include(x => x.Kennel)
                .FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }
}
