using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AbilityCharacterManager : BaseManager<AbilityCharacter, IAbilityCharacterDal>, IAbilityCharacterService
{
    public AbilityCharacterManager(IAbilityCharacterDal tdal) : base(tdal)
    {
    }
}
