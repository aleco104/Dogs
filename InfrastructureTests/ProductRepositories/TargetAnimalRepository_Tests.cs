using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;
using ClassLibrary1.ProductRepositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.ProductRepositories;

public class TargetAnimalRepository_Tests
{
    private readonly ProductContext _context =
    new ProductContext(new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveTargetAnimalEntity_AndReturnEntity()
    {
        //Arrange
        var targetAnimalRepository = new TargetAnimalRepository(_context);
        var testTargetAnimal = new TargetAnimal { AnimalName = "Test" };

        //Act
        var result = targetAnimalRepository.Create(testTargetAnimal);


        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.AnimalName);
    }

    [Fact]
    public void GetOne_ShouldGetOneTargetAnimal_IfLambdaExpression()
    {
        //Arrange
        var targetAnimalRepository = new TargetAnimalRepository(_context);
        var testTargetAnimal = new TargetAnimal { AnimalName = "Test" };
        targetAnimalRepository.Create(testTargetAnimal);

        //Act
        var result = targetAnimalRepository.GetOne(x => x.AnimalName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.AnimalName);
    }

    [Fact]
    public void GetAll_ShouldGetListOfTargetAnimalEntity_AndReturnTargetAnimalEntityList()
    {
        //Arrange
        var targetAnimalRepository = new TargetAnimalRepository(_context);

        //Act
        var result = targetAnimalRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<TargetAnimal>>(result);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateTargetAnimal_IfTargetAnimalIsNotNull_AndReturnUpdatedTargetAnimalEntity()
    {
        //Arrange
        var targetAnimalRepository = new TargetAnimalRepository(_context);
        var testTargetAnimal = new TargetAnimal { AnimalName = "Test" };
        targetAnimalRepository.Create(testTargetAnimal);
        testTargetAnimal = targetAnimalRepository.GetOne(x => x.AnimalName == "Test");
        testTargetAnimal.AnimalName = "Test2";

        //Act
        var result = targetAnimalRepository.Update(x => x.AnimalName == "Test", testTargetAnimal);

        //Assert
        Assert.Equal("Test2", result.AnimalName);
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_ShouldDeleteTargetAnimalEntity_IfTargetAnimalIsNotNull_AndReturnTrue()
    {
        //Arrange
        var targetAnimalRepository = new TargetAnimalRepository(_context);
        var testTargetAnimal = new TargetAnimal { AnimalName = "Test" };
        targetAnimalRepository.Create(testTargetAnimal);

        //Act
        var result = targetAnimalRepository.Delete(x => x.AnimalName == "Test");

        //Assert
        Assert.True(result);
    }
}
