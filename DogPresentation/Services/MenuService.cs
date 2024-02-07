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
        Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine($"{"1.",-4} Add New Owner");
            Console.WriteLine($"{"2.",-4} Show All Owners");
            Console.WriteLine($"{"3.",-4} Delete Owner");
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
        Console.Clear();

        Console.WriteLine(":::: LIST OF ALL OWNERS ::::");
        var result = _ownerService.GetAllOwners();

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


    public void DogMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(":::: DOG MENU OPTIONS ::::");
            Console.WriteLine();
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

    public void ShowOneDogMenu()
    {
        Console.Clear();
        Console.WriteLine(":::: SHOW ONE DOG ::::");
        Console.WriteLine("Enter ID of the dog you would like to view: ");
        int dogId = int.Parse(Console.ReadLine()!);

        var result = _dogService.GetOneDog(dogId);

        Console.WriteLine();
        Console.WriteLine($"Birth name: {result.BirthName}");
        Console.WriteLine($"Nickname: {result.NickName}");
        Console.WriteLine($"Sex: {result.Sex}");
        Console.WriteLine($"Color: {result.Color.ColorName}");
        Console.WriteLine($"Breed: {result.Breed.BreedName}");
        Console.WriteLine($"Kennel: {result.Kennel.KennelName}");
        Console.Write($"Owner ID: {result.Owner.OwnerId}.   ");
        Console.Write($"Owner: {result.Owner.OwnerName}");
        Console.ReadKey();
    }

    public void ShowAllDogsMenu()
    {
        Console.Clear();

        Console.WriteLine(":::: LIST OF ALL DOGS ::::");
        var result = _dogService.GetAllDogs();

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

        var result = _dogService.UpdateDog(dogIdToUpdate);

        if (result)
        {
            Console.WriteLine("Dog was successfully updated!");
        }
        else
        {
            Console.WriteLine("Something went wrong. Please try again.");
        }

        Console.ReadKey();
    }
}    
    


