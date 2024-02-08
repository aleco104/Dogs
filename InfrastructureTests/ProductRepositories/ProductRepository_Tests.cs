using ClassLibrary1.Contexts;
using ClassLibrary1.ProductEntities;
using ClassLibrary1.ProductRepositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests.ProductRepositories;

public class ProductRepository_Tests
{
    private readonly ProductContext _context =
    new ProductContext(new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

    [Fact]
    public void Create_ShouldCreateAndSaveProductEntity_AndReturnEntity()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var testProduct = new Product { ProductName = "Test", Price = 1 };

        //Act
        var result = productRepository.Create(testProduct);


        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.ProductName);
    }

    [Fact]
    public void GetOne_ShouldGetOneProduct_IfLambdaExpression()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var testCategory = new Category { CategoryName = "Test" };
        categoryRepository.Create(testCategory);

        var targetAnimalRepository = new TargetAnimalRepository(_context);
        var testAnimal = new TargetAnimal { AnimalName = "Dog" };
        targetAnimalRepository.Create(testAnimal);

        var manufacturerRepository = new ManufacturerRepository(_context);
        var testManufacturer = new Manufacturer { ManufacturerName = "Test" };
        manufacturerRepository.Create(testManufacturer);

        var productRepository = new ProductRepository(_context);
        var testProduct = new Product { ProductName = "Test", Price = 1 , AnimalId = 1, CategoryId = 1, ManufacturerId = 1 };
        productRepository.Create(testProduct);

        //Act
        var result = productRepository.GetOne(x => x.ProductName == "Test");

        //Assert
        Assert.NotNull (result);
        Assert.Equal ("Test", result.ProductName);
        Assert.Equal("Dog", result.Animal!.AnimalName);
    }

    [Fact]
    public void GetAll_ShouldGetListOfProductEntity_AndReturnProductEntityList()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var testProduct = new Product { ProductName = "Test", Price = 1 };
        var testProduct2 = new Product { ProductName = "Test2", Price = 2 };
        productRepository.Create(testProduct);
        productRepository.Create(testProduct2);

        //Act
        var result = productRepository.GetAll();

        //Assert
        Assert.True(result.Any());
    }


    [Fact]
    public void Update_ShouldFindAndUpdateProduct_IfProductIsNotNull_AndReturnUpdatedProductEntity()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var testProduct = new Product { ProductName = "Test", Price = 1 };
        productRepository.Create(testProduct);
        testProduct = productRepository.GetOne(x => x.ProductName == "Test");
        testProduct.ProductName = "Test2";

        //Act
        var result = productRepository.Update(x => x.ProductName == "Test", testProduct);

        //Assert
        Assert.Equal("Test2", result.ProductName);
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_ShouldDeleteProductEntity_IfProductIsNotNull_AndReturnTrue()
    {
        //Arrange        
        var productRepository = new ProductRepository(_context);
        var testProduct = new Product { ProductName = "Test", Price = 1 };
        productRepository.Create(testProduct);

        //Act
        var result = productRepository.Delete(x => x.Price == 1);

        //Assert
        Assert.True(result);
    }

}
