using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using System.Diagnostics;

namespace ClassLibrary1.Services;

public class OwnerService(AddressRepository addressRepository, OwnerRepository ownerRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;
    private readonly OwnerRepository _ownerRepository = ownerRepository;

    public bool AddOwner(string name, int phoneNumber, string email, string streetName, string postalCode, string city)
    {
       try
        {   //hämtar en adress med samma indata som ovan:
            var result = _addressRepository.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (result == null) //om det inte finns någon likadan adress registrerad:
            {
                var address = new AddressEntity { City = city, PostalCode = postalCode, StreetName = streetName };
                result = _addressRepository.Create(address); //lägg till den som en ny AddressEntity
            }

            var owner = new OwnerEntity { OwnerName = name, Email = email, PhoneNumber = phoneNumber, AddressId = result.AddressId };
            var ownerResult = _ownerRepository.Create(owner);

            if (ownerResult != null)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        
        return false;
    }
}
