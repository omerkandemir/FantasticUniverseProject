using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureManager : BaseManagerAsync<Adventure, IAdventureDal>, IAdventureService
{
    public AdventureManager(IAdventureDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateAdventureValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Adventure value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateAdventureValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Adventure value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteAdventureValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Adventure value)
    {
        return base.DeleteAsync(value);
    }

    public async Task<IDataReturnType<ICollection<Adventure>>> GetAdventuresByPlanetId(int planetId)
    {
        try
        {
            var adventures = (await _tdal.GetAllAsync()).Where(a => a.PlanetId == planetId).ToList();
            return new DataReturnType<ICollection<Adventure>>(adventures, GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<ICollection<Adventure>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}
