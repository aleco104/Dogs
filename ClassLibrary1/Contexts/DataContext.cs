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
    public virtual DbSet<DogEntity> Dogs { get; set; }
    public virtual DbSet<KennelEntity> Kennels { get; set; }
    public virtual DbSet<OwnerEntity> Owners { get; set; }
}


//public DataContext()
//{
//}
//public DataContext(DbContextOptions options) : base(options)
//{
//}
//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    optionsBuilder.UseInMemoryDatabase($"{Guid.NewGuid()}");
//}
//public DbSet<ProductEntity> Products { get; set; }
