using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;

namespace ClassLibrary1.Repositories;

public class KennelRepository(DataContext context) : Repo<KennelEntity>(context)
{
    private readonly DataContext _context = context;
}
