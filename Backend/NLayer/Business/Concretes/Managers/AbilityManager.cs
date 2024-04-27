using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AbilityManager : BaseManager<Ability, IAbilityDal>, IAbilityService
{
    public AbilityManager(IAbilityDal tdal) : base(tdal)
    {
    }
}
