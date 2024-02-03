using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;

namespace ClassLibrary1.Repositories;

public class BreedRepository(DataContext context) : Repo<BreedEntity>(context)
{
    private readonly DataContext _context = context;
}
