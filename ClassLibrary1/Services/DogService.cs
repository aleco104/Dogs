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

            var dogEntity = new DogEntity { BirthDate = birthDate, BirthName = birthName, NickName = nickName, Sex = sex, ColorId = colorId, BreedId = breedId, OwnerId = ownerId, KennelId = kennelId };
            var result = _dogRepository.Create(dogEntity);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return true;
    }

    public DogEntity GetOneDog(int dogId)
    {
        try
        {
            var result = _dogRepository.GetOne(x => x.DogId == dogId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public IEnumerable<DogEntity>GetAllDogs()
    {
        try
        {
            var result = _dogRepository.GetAll();
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public bool DeleteDog(int dogId)
    {
        try
        {
            var result = _dogRepository.Delete(x => x.OwnerId == dogId);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    public bool UpdateDog(int dogId)
    {
        try
        {
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return true;
    }
}
