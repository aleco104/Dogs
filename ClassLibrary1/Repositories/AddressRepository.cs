using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;

namespace ClassLibrary1.Repositories;

public class AddressRepository(DataContext context) : Repo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}
