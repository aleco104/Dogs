using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class KennelRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveKennelEntity_AndReturnEntity()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);
        var testKennelEntity = new KennelEntity { KennelName = "Test" };

        //Act
        var result = kennelRepository.Create(testKennelEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.KennelName);
    }

    [Fact]
    public void Create_ShouldNotCreateAndSaveKennelEntity_AndReturnNull()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);
        var testKennelEntity = new KennelEntity { KennelName = "Test" };
        kennelRepository.Create(testKennelEntity);

        //Act
        var result = kennelRepository.Create(testKennelEntity);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldGetListOfKennelEntity_AndReturnKennelEntityList()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);

        //Act
        var result = kennelRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<KennelEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneKennel_IfLambdaExpression()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);
        var kennelEntity = new KennelEntity { KennelName = "Test" };
        kennelRepository.Create(kennelEntity);

        //Act
        var result = kennelRepository.GetOne(x => x.KennelName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.KennelName);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateOneKennel_IfKennelIsNotNull_AndReturnUpdatedKennelEntity()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);
        var testKennelEntity = new KennelEntity { KennelName = "Test" };
        kennelRepository.Create(testKennelEntity);
        testKennelEntity = kennelRepository.GetOne(x => x.KennelName == "Test");
        testKennelEntity.KennelName = "Test2";

        //Act
        var result = kennelRepository.Update(x => x.KennelName == "Test", testKennelEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test2", result.KennelName);
    }

    [Fact]
    public void Delete_ShouldDeleteKennelEntity_IfKennelIsNotNull_AndReturnTrue()
    {
        //Arrange
        var kennelRepository = new KennelRepository(_context);
        var testKennelEntity = new KennelEntity { KennelName = "Test" };
        kennelRepository.Create(testKennelEntity);

        //Act
        var result = kennelRepository.Delete(x => x.KennelName == "Test");

        //Assert
        Assert.True(result);
    }
}
