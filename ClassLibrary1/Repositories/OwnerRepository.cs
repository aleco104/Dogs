using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace ClassLibrary1.Repositories;

public class OwnerRepository(DataContext context) : Repo<OwnerEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<OwnerEntity> GetAll()
    {
        try
        {
            return _context.Owners
                .Include(x => x.Address)
                .ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public override OwnerEntity GetOne(Expression<Func<OwnerEntity, bool>> predicate)
    {
        try
        {
            return _context.Owners
                .Include(x => x.Address)
                .FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }
}
