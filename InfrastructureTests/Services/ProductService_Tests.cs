using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;
using ClassLibrary1.ProductRepositories;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.Services;

public class ProductService_Tests
{
    private readonly ProductContext _context =
    new ProductContext(new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void AddProduct_ShouldAddProductEntity_AndReturnTrue()
    {
        //Arrange
        var _productRepository = new ProductRepository(_context);
        var _categoryRepository = new CategoryRepository(_context);
        var _manufacturerRepository = new ManufacturerRepository(_context);
        var _targetAnimalRepository = new TargetAnimalRepository(_context);
        var _productService = new ProductService(_productRepository, _categoryRepository, _manufacturerRepository, _targetAnimalRepository);

        //Act
        var result = _productService.AddProduct("Test", 1, "Test", "Test", "Test");

        //Assert
        Assert.True( result );
    }

    [Fact]
    public void GetOneProduct_ShouldGetOneProductEntity_AndReturnProductEntity()
    {
        //Arrange
        var _productRepository = new ProductRepository(_context);
        var _categoryRepository = new CategoryRepository(_context);
        var _manufacturerRepository = new ManufacturerRepository(_context);
        var _targetAnimalRepository = new TargetAnimalRepository(_context);
        var _productService = new ProductService(_productRepository, _categoryRepository, _manufacturerRepository, _targetAnimalRepository);
         _productService.AddProduct("Test", 1, "Test", "Test", "Test");

        //Act
        var result = _productService.GetOneProduct(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.ProductId);
    }

    [Fact]
    public void GetAllProducts_ShouldGetAllProducts_AndReturnListOfProductEntities()
    {
        //Arrange
        var _productRepository = new ProductRepository(_context);
        var _categoryRepository = new CategoryRepository(_context);
        var _manufacturerRepository = new ManufacturerRepository(_context);
        var _targetAnimalRepository = new TargetAnimalRepository(_context);
        var _productService = new ProductService(_productRepository, _categoryRepository, _manufacturerRepository, _targetAnimalRepository);
        _productService.AddProduct("Test", 1, "Test", "Test", "Test");

        //Act
        var result = _productService.GetAllProducts();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(result);
    }

    [Fact]
    public void DeleteProduct_ShouldDeleteProductEntity_AndReturnTrue()
    {
        //Arrange
        var _productRepository = new ProductRepository(_context);
        var _categoryRepository = new CategoryRepository(_context);
        var _manufacturerRepository = new ManufacturerRepository(_context);
        var _targetAnimalRepository = new TargetAnimalRepository(_context);
        var _productService = new ProductService(_productRepository, _categoryRepository, _manufacturerRepository, _targetAnimalRepository);
        _productService.AddProduct("Test", 1, "Test", "Test", "Test");

        //Act
        var result = _productService.DeleteProduct(1);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteProduct_ShouldNotDeleteProductEntity_AndReturnFalse()
    {
        //Arrange
        var _productRepository = new ProductRepository(_context);
        var _categoryRepository = new CategoryRepository(_context);
        var _manufacturerRepository = new ManufacturerRepository(_context);
        var _targetAnimalRepository = new TargetAnimalRepository(_context);
        var _productService = new ProductService(_productRepository, _categoryRepository, _manufacturerRepository, _targetAnimalRepository);
        _productService.AddProduct("Test", 1, "Test", "Test", "Test");

        //Act
        var result = _productService.DeleteProduct(2);

        //Assert
        Assert.False(result);
    }
}
