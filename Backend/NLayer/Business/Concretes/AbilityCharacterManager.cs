using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AbilityCharacterManager : IAbilityCharacterService
{
    private readonly IAbilityCharacterDal _abilityCharacterDal;
    public AbilityCharacterManager(IAbilityCharacterDal abilityCharacterDal)
    {
        _abilityCharacterDal = abilityCharacterDal;
    }
    public void Add(AbilityCharacter abilityCharacter)
    {
        _abilityCharacterDal.Add(abilityCharacter);
    }
    public void Update(AbilityCharacter abilityCharacter)
    {
        _abilityCharacterDal.Update(abilityCharacter);
    }
    public void Delete(AbilityCharacter abilityCharacter)
    {
        _abilityCharacterDal.Delete(abilityCharacter);
    }

    public AbilityCharacter Get(int id)
    {
        return _abilityCharacterDal.Get(x => x.Id == id);
    }

    public List<AbilityCharacter> GetAll()
    {
        return _abilityCharacterDal.GetAll();
    }
}
