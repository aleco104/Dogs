using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class DogRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void GetAll_ShouldGetListOfDogEntities_AndReturnList()
    {
        //Arrange
        var dogRepository = new DogRepository( _context );

        //Act
        var result = dogRepository.GetAll();

        //Assert
        Assert.IsAssignableFrom<IEnumerable<ProductEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneDogEntity_AndReturnOneDogEntity()
    {
        //Arrange
        new BreedRepository(_context).Create(new BreedEntity { BreedName = "Test", SizeClass = "Test" });
        new ColorRepository(_context).Create(new ColorEntity { ColorName = "Test" });
        new KennelRepository(_context).Create(new KennelEntity { KennelName = "Test" });
        new AddressRepository( _context ).Create(new AddressEntity { StreetName = "Test", PostalCode = "Test", City = "Test" });
        new OwnerRepository( _context ).Create(new OwnerEntity { OwnerName = "Test", AddressId = 1, Email="test@test.com", PhoneNumber = 13245 });

        var dogRepository = new DogRepository(_context);
        var testDogEntity = new ProductEntity { 
            BirthName = "Test",
            BirthDate = DateTime.Now,
            NickName = "Test",
            Sex = "Test",
            ColorId = 1,
            BreedId = 1,
            OwnerId = 1,
            KennelId = 1        
        };
        dogRepository.Create( testDogEntity );

        //Act
        var result = dogRepository.GetOne(x => x.BirthName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.BirthName);
    }
}
