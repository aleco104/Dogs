using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace InfrastructureTests.Services;

public class DogService_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void AddDog_ShouldAddDogEntity_AndReturnTrue()
    {
        //Arrange
        var _breedRepository = new BreedRepository(_context);
        var _colorRepository = new ColorRepository(_context);
        var _dogRepository = new DogRepository(_context);
        var _kennelRepository = new KennelRepository(_context);
        var _ownerRepository  = new OwnerRepository(_context);
        var _addressRepository = new AddressRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);
        _ownerService.AddOwner("Test", 12345, "Test", "Test", "Test", "Test");
        var _dogService = new DogService(_dogRepository, _colorRepository, _breedRepository, _kennelRepository);
        
        //Act
        var result = _dogService.AddDog(DateTime.Now, "Test", "Test", "Test", "Test", "Test", 1, "Test");

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void GetOneDog()
    {
        //Arrange
        var _breedRepository = new BreedRepository(_context);
        var _colorRepository = new ColorRepository(_context);
        var _dogRepository = new DogRepository(_context);
        var _kennelRepository = new KennelRepository(_context);
        var _ownerRepository  = new OwnerRepository(_context);
        var _addressRepository = new AddressRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);
        var _dogService = new DogService(_dogRepository, _colorRepository, _breedRepository, _kennelRepository);

        _ownerService.AddOwner("Test", 12345, "Test", "Test", "Test", "Test");
        _dogService.AddDog(DateTime.Now, "Test", "Test", "Test", "Test", "Test", 1, "Test");

        //Act 
        var result = _dogService.GetOneDog(1);

        //Assert
        Assert.IsType<DogEntity>(result);
        Assert.Equal(1, result.DogId);
    }

    [Fact]
    public void GetAllDogs_ShouldGetAllDogs_AndReturnList()
    {
        //Arrange
        var _breedRepository = new BreedRepository(_context);
        var _colorRepository = new ColorRepository(_context);
        var _dogRepository = new DogRepository(_context);
        var _kennelRepository = new KennelRepository(_context);
        var _ownerRepository = new OwnerRepository(_context);
        var _addressRepository = new AddressRepository(_context);
        var _ownerService = new OwnerService(_addressRepository, _ownerRepository);
        var _dogService = new DogService(_dogRepository, _colorRepository, _breedRepository, _kennelRepository);

        _ownerService.AddOwner("Test", 12345, "Test", "Test", "Test", "Test");
        _dogService.AddDog(DateTime.Now, "Test", "Test", "Test", "Test", "Test", 1, "Test");

        //Act
        var result = _dogService.GetAllDogs();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<DogEntity>>(result);
    }

    [Fact]
    public void DeleteDog_ShouldDeleteDog_AndReturnTrue()
    {
        //Arrange
        var _breedRepository = new BreedRepository(_context);
        var _colorRepository = new ColorRepository(_context);
        var _dogRepository = new DogRepository(_context);
        var _kennelRepository = new KennelRepository(_context);
        var _dogService = new DogService(_dogRepository, _colorRepository, _breedRepository, _kennelRepository);

        _dogService.AddDog(DateTime.Now, "Test", "Test", "Test", "Test", "Test", 1, "Test");

        //Act
        var result = _dogService.DeleteDog(1);

        //Assert
        Assert.True(result);
    }
}
