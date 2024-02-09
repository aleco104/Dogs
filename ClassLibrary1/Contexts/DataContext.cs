using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Contexts;

public class DataContext : DbContext
{
    protected DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public virtual DbSet<AddressEntity> Addresses { get; set; }
    public virtual DbSet<BreedEntity> Breeds { get; set; }
    public virtual DbSet<ColorEntity> Colors { get; set; }
    public virtual DbSet<ProductEntity> Dogs { get; set; }
    public virtual DbSet<KennelEntity> Kennels { get; set; }
    public virtual DbSet<OwnerEntity> Owners { get; set; }
}


