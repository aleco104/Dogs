using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class AddressRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveAddressEntity_AndReturnEntity()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var testAddressEntity = new AddressEntity { StreetName = "Renstigen", PostalCode = "61431", City = "Söderköping" };

        //Act
        var result = addressRepository.Create(testAddressEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.AddressId);
    }

    [Fact]
    public void Create_ShouldNotCreateAndSaveAddressEntity_AndReturnNull()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var testAddressEntity = new AddressEntity { StreetName = "Renstigen", PostalCode = "61431", City = "Söderköping" };
        addressRepository.Create(testAddressEntity);

        //Act
        var result = addressRepository.Create(testAddressEntity);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldGetListOfAddressEntity_AndReturnAddressEntityList()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);

        //Act
        var result = addressRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<AddressEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneAddress_IfLambdaExpression()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressEntity = new AddressEntity { StreetName = "Test", PostalCode = "Test", City = "Test"};
        addressRepository.Create(addressEntity);

        //Act
        var result = addressRepository.GetOne(x => x.StreetName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.StreetName);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateOneAddress_IfAddressIsNotNull_AndReturnUpdatedAddressEntity()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var testAddressEntity = new AddressEntity { StreetName = "Test", PostalCode = "Test", City = "Test" };
        addressRepository.Create(testAddressEntity);
        testAddressEntity = addressRepository.GetOne(x => x.StreetName == "Test");
        testAddressEntity.StreetName = "Test2";

        //Act
        var result = addressRepository.Update(x=>x.StreetName == "Test", testAddressEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test2", result.StreetName);
    }

    [Fact]
    public void Delete_ShouldDeleteAddressEntity_IfAddressIsNotNull_AndReturnTrue()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var testAddressEntity = new AddressEntity { StreetName = "Test", PostalCode = "Test", City = "Test" };
        addressRepository.Create(testAddressEntity);

        //Act
        var result = addressRepository.Delete(x => x.StreetName == "Test");

        //Assert
        Assert.True(result);
    }
}







