using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System.Diagnostics.Eventing.Reader;

namespace DogPresentation.Services;

public class MenuService
{
    private readonly OwnerService _ownerService;
    private readonly DogService _dogService;
    private readonly ProductService _productService;

    public MenuService(OwnerService ownerService, DogService dogService, ProductService productService)
    {
        _ownerService = ownerService;
        _dogService = dogService;
        _productService = productService;
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: DOG DATABASE - MAIN MENU ::::");
        Console.WriteLine();
        Console.WriteLine($"{"1.",-4} Add New Dog");
        Console.WriteLine($"{"2.",-4} Update Dog Information");
        Console.WriteLine($"{"3.",-4} Show One Dog");
        Console.WriteLine($"{"4.",-4} Show All Dogs");
        Console.WriteLine($"{"5.",-4} Delete Dog");
        Console.WriteLine($"{"6.",-4} Manage Owners");
        Console.WriteLine($"{"7.",-4} Manage Products");
        Console.WriteLine($"{"0.",-4} Exit Application");
        Console.WriteLine();
        Console.Write("Enter Menu Option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddDogMenu();
                break;
            case "2":
                UpdateDogMenu();
                break;
            case "3":
                ShowOneDogMenu();
                break;
            case "4":
                ShowAllDogsMenu();
                break;
            case "5":
                DeleteDogMenu();
                break;
            case "6":
                OwnerMainMenu();
                break;
            case "7":
                ProductMainMenu();
                break;
            default:
                Console.WriteLine("\nInvalid Option. Press any key to try again.");
                Console.ReadKey();
                break;
        }
    }

    public void OwnerMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(":::: OWNER MENU OPTIONS ::::");
            Console.WriteLine();
            Console.WriteLine($"{"1.",-4} Add New Owner");
            Console.WriteLine($"{"2.",-4} Show All Owners");
            Console.WriteLine($"{"3.",-4} Delete Owner");
            Console.WriteLine($"{"0.",-4} Go to main menu");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddOwnerMenu();
                    break;
                case "2":
                    ShowAllOwnersMenu();
                    break;
                case "3":
                    DeleteOwnerMenu();
                    break;
                case "0":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("\nInvalid Option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void ExitApplication()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to close this application? (y/n)");
        var option = Console.ReadLine() ?? "";

        if (option.ToLower() == "y")
            Environment.Exit(0);
    }

    public void AddOwnerMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: ADD OWNER MENU ::::");
        Console.WriteLine();
        Console.Write("Name: ");
        var name = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        var phoneNumber = int.Parse(Console.ReadLine()!);

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Streetname: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postalcode: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        var result = _ownerService.AddOwner(name, phoneNumber, email, streetName, postalCode, city);
        Console.Clear();

        if (result == true)
        {
            Console.WriteLine("Owner was created successfully!");
        }
        else
        {
            Console.WriteLine("Owner was not created. Please try again.");
        }
        Console.ReadKey();
    }

    public void ShowAllOwnersMenu()
    {
        var result = _ownerService.GetAllOwners();
        Console.Clear();
        Console.WriteLine(":::: LIST OF ALL OWNERS ::::");

        foreach (var owner in result)
        {
            Console.WriteLine();
            Console.Write($"Owner ID: {owner.OwnerId}. | ");
            Console.Write($"Name: {owner.OwnerName} | ");
            Console.Write($"Email Address: {owner.Email} | ");
        }
        Console.ReadKey();
    }

    public void DeleteOwnerMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: DELETE OWNER ::::");
        Console.WriteLine();
        Console.Write("Enter ID of the owner to delete: ");
        int ownerToDelete = int.Parse(Console.ReadLine()!);

        var result = _ownerService.DeleteOwner(ownerToDelete);
        Console.Clear();

        if (result)
        {
            Console.WriteLine("Owner was deleted!");
        }
        else
        {
            Console.WriteLine("Something went wrong. Please try again.");
        }

        Console.ReadKey();
    }


    // -------------------------------------------------------------------------------------------------------------------------------------

    public void AddDogMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: ADD DOG MENU ::::");
        Console.WriteLine();

        Console.Write("Birthdate YYYY-MM-DD: ");
        var birthDate = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Birthname: ");
        var birthName = Console.ReadLine()!;

        Console.Write("Nickname: ");
        var nickName = Console.ReadLine()!;

        Console.Write("Sex (Male/Female): ");
        var sex = Console.ReadLine()!;

        Console.Write("Color: ");
        var color = Console.ReadLine()!;

        Console.Write("Breed: ");
        var breed = Console.ReadLine()!;

        Console.Write("Owner ID: ");
        var ownerId = int.Parse(Console.ReadLine()!);

        Console.Write("Kennel Name: ");
        var kennel = Console.ReadLine()!;

        var result = _dogService.AddDog(birthDate, birthName, nickName, sex, color, breed, ownerId, kennel);
        Console.Clear();

        if (result == true)
        {
            Console.WriteLine("Dog created successfully!");
        }
        else
        {
            Console.WriteLine("Dog was not created. Please try again.");
        }
        Console.ReadKey();
    }

    public void ShowOneDogMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: SHOW ONE DOG ::::");
        Console.WriteLine();
        Console.Write("Enter ID of the dog you would like to view: ");
        int dogId = int.Parse(Console.ReadLine()!);

        var result = _dogService.GetOneDog(dogId);
        Console.Clear();

        if (result != null)
        {
            Console.WriteLine(":::: DOG INFORMATION ::::");
            Console.WriteLine();
            Console.WriteLine($"Birth date: {result.BirthDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Birth name: {result.BirthName}");
            Console.WriteLine($"Nickname: {result.NickName}");
            Console.WriteLine($"Sex: {result.Sex}");
            Console.WriteLine($"Color: {result.Color.ColorName}");
            Console.WriteLine($"Breed: {result.Breed.BreedName}");
            Console.WriteLine($"Kennel: {result.Kennel.KennelName}");
            Console.Write($"Owner ID: {result.Owner.OwnerId}.   ");
            Console.Write($"Owner: {result.Owner.OwnerName}");
        }
        else
        {
            Console.WriteLine("Dog was not found.");
        }
        Console.ReadKey();
    }

    public void ShowAllDogsMenu()
    {
        var result = _dogService.GetAllDogs();
        Console.Clear();

        Console.WriteLine(":::: LIST OF ALL DOGS ::::");
        foreach (var dog in result)
        {
            Console.WriteLine();
            Console.Write($"Dog ID: {dog.DogId} | ");
            Console.Write($"Birth name: {dog.BirthName} | ");
            Console.Write($"Nickname: {dog.NickName} | ");
            Console.Write($"Sex: {dog.Sex} | ");
            Console.Write($"Breed: {dog.Breed.BreedName} | ");
            Console.WriteLine();
            Console.Write($"Owner ID: {dog.Owner.OwnerId} | ");
            Console.Write($"Owner: {dog.Owner.OwnerName} | ");
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public void DeleteDogMenu() 
    { 
        Console.Clear();
        Console.WriteLine(":::: DELETE OWNER ::::");
        Console.WriteLine();
        Console.Write("Enter ID of the dog to delete: ");
        int dogIdToDelete = int.Parse(Console.ReadLine()!);

        var result = _dogService.DeleteDog(dogIdToDelete);
        Console.Clear();

        if (result)
        {
            Console.WriteLine("Dog was successfully deleted!");
        }
        else
        {
            Console.WriteLine("Something went wrong. Please try again.");
        }

        Console.ReadKey();
    }

    public void UpdateDogMenu() 
    {
        Console.Clear();
        Console.WriteLine(":::: UPDATE DOG INFORMATION ::::");
        Console.WriteLine();
        Console.Write("Enter ID of the dog to update: ");
        int dogIdToUpdate = int.Parse(Console.ReadLine()!);

        var result = _dogService.GetOneDog(dogIdToUpdate);
        Console.Clear();
        
        if (result != null)
        {
            Console.WriteLine(":::: UPDATE DOG INFORMATION ::::");
            Console.WriteLine();
            Console.WriteLine($"Birth date: {result.BirthDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Birth name: {result.BirthName}");
            Console.WriteLine($"Nickname: {result.NickName}");
            Console.WriteLine($"Sex: {result.Sex}");
            Console.WriteLine($"Color: {result.Color.ColorName}");
            Console.WriteLine($"Breed: {result.Breed.BreedName}");
            Console.WriteLine($"Kennel: {result.Kennel.KennelName}");
            Console.Write($"Owner ID: {result.Owner.OwnerId}.   ");
            Console.Write($"Owner: {result.Owner.OwnerName}");
            Console.WriteLine("\n");

            Console.Write("New birthdate YYYY-MM-DD: ");
            var birthDate = DateTime.Parse(Console.ReadLine()!);

            Console.Write("New birthname: ");
            var birthName = Console.ReadLine()!;
            if (string.IsNullOrEmpty(birthName))
            {
                birthName = result.BirthName;
            }

            Console.Write("New nickname: ");
            var nickName = Console.ReadLine()!;
            if (string.IsNullOrEmpty(nickName))
            {
                nickName = result.NickName;
            }

            Console.Write("New sex (Male/Female): ");
            var sex = Console.ReadLine()!;
            if (string.IsNullOrEmpty(sex))
            {
                sex = result.Sex;
            }

            Console.Write("New color: ");
            var color = Console.ReadLine()!;
            if (string.IsNullOrEmpty(color))
            {
                color = result.Color.ColorName;
            }

            Console.Write("New breed: ");
            var breed = Console.ReadLine()!;
            if (string.IsNullOrEmpty(breed))
            {
                breed = result.Breed.BreedName;
            }

            Console.Write("New owner ID: ");
            var ownerId = int.Parse(Console.ReadLine()!);

            Console.Write("New kennel name: ");
            var kennel = Console.ReadLine()!;
            if (string.IsNullOrEmpty(kennel))
            {
                kennel = result.Kennel.KennelName;
            }

            var updatedDog = _dogService.UpdateDog(dogIdToUpdate, birthDate, birthName, nickName!, sex, color, breed, ownerId, kennel);
            Console.Clear();

            if (updatedDog)
            {
                Console.WriteLine("Dog was successfully updated!");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Dog was not found.");
        }

        Console.ReadKey();
    }

    //----------------------------------------------------------------------------------------------------------

    public void ProductMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(":::: PRODUCT MENU OPTIONS ::::");
            Console.WriteLine();
            Console.WriteLine($"{"1.",-4} Add New Product");
            Console.WriteLine($"{"2.",-4} Show One Product");
            Console.WriteLine($"{"3.",-4} Show All Products");
            Console.WriteLine($"{"4.",-4} Delete Product");
            Console.WriteLine($"{"0.",-4} Go to main menu");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddProductMenu();
                    break;
                case "2":
                    ShowOneProductMenu();
                    break;
                case "3":
                    ShowAllProductsMenu();
                    break;
                case "4":
                    DeleteProductMenu();
                    break;
                case "0":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("\nInvalid Option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void AddProductMenu() 
    {
        Console.Clear();
        Console.WriteLine(":::: ADD PRODUCT MENU ::::");
        Console.WriteLine();
        Console.Write("Product name: ");
        var productName = Console.ReadLine()!;

        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Category name: ");
        var categoryName = Console.ReadLine()!;

        Console.Write("Manufacturer: ");
        var manufacturerName = Console.ReadLine()!;

        Console.Write("Target animal: ");
        var animalName = Console.ReadLine()!;

        var result = _productService.AddProduct(productName, price, categoryName, manufacturerName, animalName);
        Console.Clear();

        if (result == true)
        {
            Console.WriteLine("Product was created successfully!");
        }
        else
        {
            Console.WriteLine("Product was not created. Please try again.");
        }
        Console.ReadKey();
    }

    public void ShowOneProductMenu() 
    {
        Console.Clear();
        Console.WriteLine(":::: SHOW ONE PRODUCT ::::\n");
        Console.Write("Enter ID of the product you would like to view: ");
        int productId = int.Parse(Console.ReadLine()!);

        var result = _productService.GetOneProduct(productId);
        Console.Clear();

        if (result!=null)
        {
            Console.WriteLine(":::: SHOW ONE PRODUCT ::::");
            Console.WriteLine();
            Console.WriteLine($"Product: {result.ProductId}");
            Console.WriteLine($"Product: {result.ProductName}");
            Console.WriteLine($"Price: {result.Price:0.00}");
            Console.WriteLine($"Category: {result.Category!.CategoryName}");
            Console.WriteLine($"Manufacturer: {result.Manufacturer!.ManufacturerName}");
            Console.WriteLine($"Animal: {result.Animal!.AnimalName}");
        }
        else
        {
            Console.WriteLine("Product was not found.");
        }
        Console.ReadKey();
    }

    public void ShowAllProductsMenu() 
    { 
        var result = _productService.GetAllProducts();
        Console.Clear();
        Console.WriteLine(":::: LIST OF ALL PRODUCTS ::::");

        foreach (var product in result)
        {
            Console.WriteLine();
            Console.Write($"Article number: {product.ProductId} | ");
            Console.Write($"Product: {product.ProductName} | ");
            Console.Write($"Price: {product.Price:0.00} | ");
            Console.Write($"Category: {product.Category!.CategoryName} | ");
            Console.Write($"Manufacturer: {product.Manufacturer!.ManufacturerName}");
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    public void DeleteProductMenu() 
    {
        Console.Clear();
        Console.WriteLine(":::: DELETE PRODUCT ::::");
        Console.WriteLine();
        Console.Write("Enter ID of the product to delete: ");
        int productIdToDelete = int.Parse(Console.ReadLine()!);

        var result = _productService.DeleteProduct(productIdToDelete);
        Console.Clear();

        if (result)
        {
            Console.WriteLine("Product was successfully deleted!");
        }
        else
        {
            Console.WriteLine("Something went wrong. Please try again.");
        }

        Console.ReadKey();
    }
}    
    


