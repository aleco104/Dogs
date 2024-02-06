using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System.Diagnostics.Eventing.Reader;

namespace DogPresentation.Services;

public class MenuService
{
    private readonly OwnerService _ownerService;
    private readonly DogService _dogService;

    public MenuService(OwnerService ownerService, DogService dogService)
    {
        _ownerService = ownerService;
        _dogService = dogService;
    }

    public void MainMenu()
    {
        Console.WriteLine(":::: MAIN MENU ::::");
        Console.WriteLine($"{"1.",-4} View/Edit Owners");
        Console.WriteLine($"{"2.",-4} View/Edit Dogs");
        Console.WriteLine();
        Console.Write("Enter Menu Option: ");
        var choice = int.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            OwnerMainMenu();
        }
        else if (choice == 2)
        {
            DogMainMenu();
        }
        else
        {
            Console.WriteLine("Invalid Option. Press any key to try again.");
            Console.ReadKey();
        }
    }

    public void OwnerMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(":::: OWNER MENU OPTIONS ::::");
            Console.WriteLine($"{"1.",-4} Add New Owner");
            Console.WriteLine($"{"2.",-4} Show All Owners");
            Console.WriteLine($"{"0.",-4} Exit Application");
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
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("\nInvalid Option Selected. Press any key to try agan.");
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

        if (result == true)
        {
            Console.WriteLine("Owner created successfully!");
        }
        else
        {
            Console.WriteLine("Owner was not created. Please try again.");
        }
        Console.ReadKey();
    }

    public void DogMainMenu()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine(":::: DOG MENU OPTIONS ::::");
            Console.WriteLine($"{"1.",-4} Add New Dog");
            Console.WriteLine($"{"2.",-4} Update Dog Information");
            Console.WriteLine($"{"3.",-4} Show One Dog");
            Console.WriteLine($"{"4.",-4} Show All Dogs");
            Console.WriteLine($"{"5.",-4} Delete Dog");
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
                case "0":
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("\nInvalid Option Selected. Press any key to try agan.");
                    Console.ReadKey();
                    break;
            }
        }
    }

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

    public void DeleteOwnerMenu() { }
    public void ShowAllOwnersMenu() { }

    
    public void DeleteDogMenu() { }
    public void ShowAllDogsMenu() { }
    public void ShowOneDogMenu() { }
    public void UpdateDogMenu() { }

    
    
}

