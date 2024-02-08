using ClassLibrary1.Contexts;
using ClassLibrary1.ProductRepositories;
using System.Diagnostics;

namespace ClassLibrary1.Services;

public class ProductService(ProductRepository productRepository, CategoryRepository categoryRepository, ManufacturerRepository manufacturerRepository, TargetAnimalRepository targetAnimalRepository)
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ManufacturerRepository _manufacturerRepository = manufacturerRepository;
    private readonly TargetAnimalRepository _targetAnimalRepository = targetAnimalRepository;

    public bool AddProduct(string productName, decimal price, string categoryName, string manufacturerName, string animalName)
    {

    }
}
