using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class OwnerRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void GetAll_ShouldGetAllOwnerEntities_AndReturnList()
    {
        //Arrange
        var ownerRepository = new OwnerRepository( _context );

        //Act
        var result = ownerRepository.GetAll();

        //Assert
        Assert.IsAssignableFrom<IEnumerable<OwnerEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneOwnerEntity_AndReturnOneOwnerEntity()
    {
        //Arrange
        new AddressRepository(_context).Create(new AddressEntity { StreetName = "Test", PostalCode = "Test", City = "Test" });
        var ownerRepository = new OwnerRepository(_context);
        var testOwnerEntity = new OwnerEntity { OwnerName = "Test", PhoneNumber = 123, AddressId = 1, Email = "Test" };
        ownerRepository.Create(testOwnerEntity);

        //Act
        var result = ownerRepository.GetOne(x => x.OwnerId == 1);

        //Assert
        Assert.Equal(1, result.OwnerId);
        Assert.Equal("Test", result.Address.City);
    }
}
