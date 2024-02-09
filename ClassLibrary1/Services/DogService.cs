using ClassLibrary1.Entities;
using ClassLibrary1.Repositories;
using System.Diagnostics;

namespace ClassLibrary1.Services;

public class DogService(DogRepository dogRepository, ColorRepository colorRepository, BreedRepository breedRepository, KennelRepository kennelRepository)
{
    private readonly DogRepository _dogRepository = dogRepository;
    private readonly ColorRepository _colorRepository = colorRepository;
    private readonly BreedRepository _breedRepository = breedRepository;
    private readonly KennelRepository _kennelRepository = kennelRepository;

    public bool AddDog(DateTime birthDate, string birthName, string nickName, string sex, string color, string breed, int ownerId, string kennel)
    {
        try
        {
            var colorResult = _colorRepository.GetOne(x => x.ColorName == color);
            if (colorResult == null)
            {
                var colorEntity = new ColorEntity { ColorName = color };
                colorResult = _colorRepository.Create(colorEntity);      
            }
            var colorId = colorResult.ColorId;

            var breedResult = _breedRepository.GetOne(x => x.BreedName == breed);
            if (breedResult == null)
            {
                var breedEntity = new BreedEntity { BreedName = breed };
                breedResult = _breedRepository.Create(breedEntity);
            }
            var breedId = breedResult.BreedId;

            var kennelResult = _kennelRepository.GetOne(x => x.KennelName == kennel);
            if (kennelResult == null)
            {
                var kennelEntity = new KennelEntity { KennelName = kennel };
                kennelResult = _kennelRepository.Create(kennelEntity);
            }
            var kennelId = kennelResult.KennelId;

            var dogEntity = new ProductEntity { BirthDate = birthDate, BirthName = birthName, NickName = nickName, Sex = sex, ColorId = colorId, BreedId = breedId, OwnerId = ownerId, KennelId = kennelId };
            var result = _dogRepository.Create(dogEntity);

            if (result != null)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public ProductEntity GetOneDog(int dogId)
    {
        try
        {
            var result = _dogRepository.GetOne(x => x.DogId == dogId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public IEnumerable<ProductEntity>GetAllDogs()
    {
        try
        {
            var result = _dogRepository.GetAll();
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public bool UpdateDog(int dogId, DateTime birthDate, string birthName, string nickName, string sex, string color, string breed, int ownerId, string kennel)
    {
        try
        {
            var colorResult = _colorRepository.GetOne(x => x.ColorName == color);
            if (colorResult == null)
            {
                var colorEntity = new ColorEntity { ColorName = color };
                colorResult = _colorRepository.Create(colorEntity);
            }
            var colorId = colorResult.ColorId;

            var breedResult = _breedRepository.GetOne(x => x.BreedName == breed);
            if (breedResult == null)
            {
                var breedEntity = new BreedEntity { BreedName = breed };
                breedResult = _breedRepository.Create(breedEntity);
            }
            var breedId = breedResult.BreedId;

            var kennelResult = _kennelRepository.GetOne(x => x.KennelName == kennel);
            if (kennelResult == null)
            {
                var kennelEntity = new KennelEntity { KennelName = kennel };
                kennelResult = _kennelRepository.Create(kennelEntity);
            }
            var kennelId = kennelResult.KennelId;

            var dogToUpdate = _dogRepository.GetOne(x => x.DogId == dogId);

            dogToUpdate.BirthDate = birthDate;
            dogToUpdate.BirthName = birthName;
            dogToUpdate.NickName = nickName;
            dogToUpdate.Sex = sex;
            dogToUpdate.ColorId = colorId;
            dogToUpdate.BreedId = breedId;
            dogToUpdate.KennelId = kennelId;
            dogToUpdate.OwnerId = ownerId;


            var result = _dogRepository.Update(x => x.DogId == dogId, dogToUpdate);

            if (result != null)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public bool DeleteDog(int dogId)
    {
        try
        {
            var result = _dogRepository.Delete(x => x.DogId == dogId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }
}
