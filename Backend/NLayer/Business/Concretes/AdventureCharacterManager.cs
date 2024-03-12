using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AdventureCharacterManager : IAdventureCharacterService
{
    private readonly IAdventureCharacterDal _adventureCharacterDal;
    public AdventureCharacterManager(IAdventureCharacterDal adventureCharacterDal)
    {
        _adventureCharacterDal = adventureCharacterDal;
    }
    public void Add(AdventureCharacter adventureCharacter)
    {
        _adventureCharacterDal.Add(adventureCharacter);
    }
    public void Update(AdventureCharacter adventureCharacter)
    {
        _adventureCharacterDal.Update(adventureCharacter);
    }
    public void Delete(AdventureCharacter adventureCharacter)
    {
        _adventureCharacterDal.Delete(adventureCharacter);
    }
    public AdventureCharacter Get(int id)
    {
        return _adventureCharacterDal.Get(x => x.Id == id);
    }
    public List<AdventureCharacter> GetAll()
    {
        return _adventureCharacterDal.GetAll();
    }
}
