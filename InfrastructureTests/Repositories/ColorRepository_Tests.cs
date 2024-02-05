using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Repositories;

public class ColorRepository_Tests
{
    private readonly DataContext _context =
    new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveColorEntity_AndReturnEntity()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);
        var testColorEntity = new ColorEntity { ColorName = "Test" };

        //Act
        var result = colorRepository.Create(testColorEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.ColorName);
    }

    [Fact]
    public void Create_ShouldNotCreateAndSaveColorEntity_AndReturnNull()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);
        var testColorEntity = new ColorEntity { ColorName = "Test" };
        colorRepository.Create(testColorEntity);

        //Act
        var result = colorRepository.Create(testColorEntity);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldGetListOfColorEntity_AndReturnColorEntityList()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);

        //Act
        var result = colorRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ColorEntity>>(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneColor_IfLambdaExpression()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);
        var colorEntity = new ColorEntity { ColorName = "Test" };
        colorRepository.Create(colorEntity);

        //Act
        var result = colorRepository.GetOne(x => x.ColorName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.ColorName);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateOneColor_IfColorIsNotNull_AndReturnUpdatedColorEntity()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);
        var testColorEntity = new ColorEntity { ColorName = "Test" };
        colorRepository.Create(testColorEntity);
        testColorEntity = colorRepository.GetOne(x => x.ColorName == "Test");
        testColorEntity.ColorName = "Test2";

        //Act
        var result = colorRepository.Update(x => x.ColorName == "Test", testColorEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test2", result.ColorName);
    }

    [Fact]
    public void Delete_ShouldDeleteColorEntity_IfColorIsNotNull_AndReturnTrue()
    {
        //Arrange
        var colorRepository = new ColorRepository(_context);
        var testColorEntity = new ColorEntity { ColorName = "Test" };
        colorRepository.Create(testColorEntity);

        //Act
        var result = colorRepository.Delete(x => x.ColorName == "Test");

        //Assert
        Assert.True(result);
    }
}
