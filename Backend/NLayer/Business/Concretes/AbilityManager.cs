using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AbilityManager : IAbilityService
{
    private readonly IAbilityDal _abilityDal;
    public AbilityManager(IAbilityDal abilityDal)
    {
        _abilityDal = abilityDal;
    }
    public void Add(Ability ability)
    {
        _abilityDal.Add(ability);
    }
    public void Update(Ability ability)
    {
        _abilityDal.Update(ability);
    }
    public void Delete(Ability ability)
    {
        _abilityDal.Delete(ability);
    }
    public Ability Get(int id)
    {
       return _abilityDal.Get(x => x.Id == id);
    }
    public List<Ability> GetAll()
    {
        return _abilityDal.GetAll();
    }


}
