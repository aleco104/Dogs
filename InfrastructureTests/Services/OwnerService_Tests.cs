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

    [Fact]
    public void GetAllOwners_ShouldGetAllOwners_AndReturnList()
    {
        //Arrange
        var _addressRepository = new AddressRepository(_context);
        var _ownerRepository = new OwnerRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);

        _ownerService.AddOwner("Test", 12345, "test", "test", "test", "test");
        _ownerService.AddOwner("Test1", 12345, "test1", "test1", "test1", "test1");

        //Act
        var result = _ownerService.GetAllOwners();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void DeleteOwner_ShouldDeleteOwner_AndReturnTrue()
    {
        //Arrange
        var _addressRepository = new AddressRepository(_context);
        var _ownerRepository = new OwnerRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);

        _ownerService.AddOwner("Test", 12345, "test", "test", "test", "test");

        //Act
        var result = _ownerService.DeleteOwner(1);

        //Assert
        Assert.True( result );
    }

    [Fact]
    public void DeleteOwner_ShouldReturnFalse_IfOwnerDoesNotExist()
    {
        //Arrange
        var _addressRepository = new AddressRepository(_context);
        var _ownerRepository = new OwnerRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);

        _ownerService.AddOwner("Test", 12345, "test", "test", "test", "test");

        //Act
        var result = _ownerService.DeleteOwner(2);

        //Assert
        Assert.False(result);
    }
}
