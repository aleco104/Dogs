using ClassLibrary1.Contexts;
using ClassLibrary1.Entities;
using ClassLibrary1.ProductEntities;
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
        try
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new Category { CategoryName = categoryName });
            }
            int categoryId = categoryEntity.CategoryId;

            var manufacturerEntity = _manufacturerRepository.GetOne(x => x.ManufacturerName == manufacturerName);
            if (manufacturerEntity == null)
            {
                manufacturerEntity = _manufacturerRepository.Create(new Manufacturer { ManufacturerName = manufacturerName });
            }
            int manufacturerId = manufacturerEntity.ManufacturerId;

            var targetAnimalEntity = _targetAnimalRepository.GetOne(x => x.AnimalName == animalName);
            if (targetAnimalEntity == null)
            {
                targetAnimalEntity = _targetAnimalRepository.Create(new TargetAnimal { AnimalName = animalName });
            }
            int targetAnimalId = targetAnimalEntity.AnimalId;

            var productEntity = _productRepository.Create(new Product { ProductName = productName, Price = price, CategoryId = categoryId, ManufacturerId = manufacturerId, AnimalId = targetAnimalId });

            if (productEntity != null)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public Product GetOneProduct(int productId)
    {
        try
        {
            var result = _productRepository.GetOne(x => x.ProductId == productId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        try
        {
            var result = _productRepository.GetAll();
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public bool DeleteProduct(int productId)
    {
        try
        {
            var result = _productRepository.Delete(x => x.ProductId == productId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }
}
