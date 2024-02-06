using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Services;

public class OwnerService_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void AddOwner_ShouldAddOneOwnerWithAnAddress_AndReturnTrue()
    {
        //Arrange
        var _addressRepository = new AddressRepository( _context );
        var _ownerRepository = new OwnerRepository( _context );
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);

        //Act
        var result = _ownerService.AddOwner("Test", 1, "Test", "Test", "Test", "Test");

        //Assert
        Assert.True( result );
    }
     
}
