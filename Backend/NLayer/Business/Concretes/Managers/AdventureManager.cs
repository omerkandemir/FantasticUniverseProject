using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureManager : BaseManager<Adventure, IAdventureDal>, IAdventureService
{
    public AdventureManager(IAdventureDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateAdventureValidator), Priority = 1)]
    public override IReturnType Add(Adventure Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateAdventureValidator), Priority = 1)]
    public override IReturnType Update(Adventure Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteAdventureValidator), Priority = 1)]
    public override IReturnType Delete(Adventure Value)
    {
        return base.Delete(Value);
    }
}
