using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;

namespace ClassLibrary1.Repositories;

public class ColorRepository(DataContext context) : Repo<ColorEntity>(context)
{
    private readonly DataContext _context = context;
}
