using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class CharacterManager : BaseManager<Character, ICharacterDal>, ICharacterService
{
    public CharacterManager(ICharacterDal tdal) : base(tdal)
    {
    }
}
