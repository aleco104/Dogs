using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.ProductEntities;
using ClassLibrary1.ProductRepositories;
using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.ProductRepositories;

public class CategoryRepository_Tests
{
    private readonly ProductContext _context =
    new ProductContext(new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveCategoryEntity_AndReturnEntity()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var testCategory = new Category { CategoryName = "Test" };

        //Act
        var result = categoryRepository.Create(testCategory);


        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.CategoryName);
    }

    [Fact]
    public void GetOne_ShouldGetOneCategory_IfLambdaExpression()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var testCategory = new Category { CategoryName = "Test" };
        categoryRepository.Create(testCategory);

        //Act
        var result = categoryRepository.GetOne(x => x.CategoryName == "Test");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.CategoryName);
    }

    [Fact]
    public void GetAll_ShouldGetListOfCategoryEntity_AndReturnCategoryEntityList()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);

        //Act
        var result = categoryRepository.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Category>>(result);
    }

    [Fact]
    public void Update_ShouldFindAndUpdateCategory_IfCategoryIsNotNull_AndReturnUpdatedCategoryEntity()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var testCategory = new Category { CategoryName = "Test" };
        categoryRepository.Create(testCategory);
        testCategory = categoryRepository.GetOne(x => x.CategoryName == "Test");
        testCategory.CategoryName = "Test2";

        //Act
        var result = categoryRepository.Update(x => x.CategoryName == "Test", testCategory);

        //Assert
        Assert.Equal("Test2", result.CategoryName);
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_ShouldDeleteCategoryEntity_IfCategoryIsNotNull_AndReturnTrue()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var testCategory = new Category { CategoryName = "Test" };
        categoryRepository.Create(testCategory);

        //Act
        var result = categoryRepository.Delete(x => x.CategoryName == "Test");

        //Assert
        Assert.True(result);
    }
}
