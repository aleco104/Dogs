using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;
using ClassLibrary1.ProductRepositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.ProductRepositories;

public class ManufacturerRepository_Tests
{
    private readonly ProductContext _context =
    new ProductContext(new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveManufacturerEntity_AndReturnEntity()
    {
        //Arrange
        var manufacturerRepository = new ManufacturerRepository(_context);
        var testManufacturer = new Manufacturer { ManufacturerName = "Test" };

        //Act
        var result = manufacturerRepository.Create(testManufacturer);


        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.ManufacturerName);
    }

    [Fact]
    public void GetOne_ShouldGetOneManufacturer_IfLambdaExpression()
    {
        //Arrange
        var manufacturerRepository = new ManufacturerRepository(_context);
        var testManufacturer = new Manufacturer { ManufacturerName = "Test" };
        manufacturerRepository.Create(testManufacturer);

        //Act
        var result = manufacturerRepository.GetOne(x => x.ManufacturerName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.ManufacturerName);
    }

    [Fact]
    public void GetAll_ShouldGetListOfManufacturerEntity_AndReturnManufacturerEntityList()
    {
        //Arrange
        var manufacturerRepository = new ManufacturerRepository(_context);

        //Act
        var result = manufacturerRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Manufacturer>>(result);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateManufacturer_IfManufacturerIsNotNull_AndReturnUpdatedManufacturerEntity()
    {
        //Arrange
        var manufacturerRepository = new ManufacturerRepository(_context);
        var testManufacturer = new Manufacturer { ManufacturerName = "Test" };
        manufacturerRepository.Create(testManufacturer);
        testManufacturer = manufacturerRepository.GetOne(x => x.ManufacturerName == "Test");
        testManufacturer.ManufacturerName = "Test2";

        //Act
        var result = manufacturerRepository.Update(x => x.ManufacturerName == "Test", testManufacturer);

        //Assert
        Assert.Equal("Test2", result.ManufacturerName);
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_ShouldDeleteManufacturerEntity_IfManufacturerIsNotNull_AndReturnTrue()
    {
        //Arrange
        var manufacturerRepository = new ManufacturerRepository(_context);
        var testManufacturer = new Manufacturer { ManufacturerName = "Test" };
        manufacturerRepository.Create(testManufacturer);

        //Act
        var result = manufacturerRepository.Delete(x => x.ManufacturerName == "Test");

        //Assert
        Assert.True(result);
    }
}
