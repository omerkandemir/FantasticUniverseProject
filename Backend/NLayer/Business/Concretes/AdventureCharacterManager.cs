using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AdventureCharacterManager : BaseManager<AdventureCharacter, IAdventureCharacterDal>, IAdventureCharacterService
{
    public AdventureCharacterManager(IAdventureCharacterDal tdal) : base(tdal)
    {
    }
}
