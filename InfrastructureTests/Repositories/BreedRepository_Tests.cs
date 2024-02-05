using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class BreedRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveBreedEntity_AndReturnEntity()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);
        var testBreedEntity = new BreedEntity { BreedName = "Test" };

        //Act
        var result = BreedRepository.Create(testBreedEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.BreedId);
    }

    [Fact]
    public void Create_ShouldNotCreateAndSaveBreedEntity_AndReturnNull()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);
        var testBreedEntity = new BreedEntity { BreedName = "Test" };
        BreedRepository.Create(testBreedEntity);

        //Act
        var result = BreedRepository.Create(testBreedEntity);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldGetListOfBreedEntity_AndReturnBreedEntityList()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);

        //Act
        var result = BreedRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<BreedEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneBreed_IfLambdaExpression()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);
        var BreedEntity = new BreedEntity { BreedName = "Test" };
        BreedRepository.Create(BreedEntity);

        //Act
        var result = BreedRepository.GetOne(x => x.BreedName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.BreedName);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateOneBreed_IfBreedIsNotNull_AndReturnUpdatedBreedEntity()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);
        var testBreedEntity = new BreedEntity { BreedName = "Test" };
        BreedRepository.Create(testBreedEntity);
        testBreedEntity = BreedRepository.GetOne(x => x.BreedName == "Test");
        testBreedEntity.BreedName = "Test2";

        //Act
        var result = BreedRepository.Update(x => x.BreedName == "Test", testBreedEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test2", result.BreedName);
    }

    [Fact]
    public void Delete_ShouldDeleteBreedEntity_IfBreedIsNotNull_AndReturnTrue()
    {
        //Arrange
        var BreedRepository = new BreedRepository(_context);
        var testBreedEntity = new BreedEntity { BreedName = "Test" };
        BreedRepository.Create(testBreedEntity);

        //Act
        var result = BreedRepository.Delete(x => x.BreedName == "Test");

        //Assert
        Assert.True(result);
    }
}
