using Microsoft.AspNetCore.Identity;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;

namespace NLayer.Business.Concretes.Managers;

public class AppUserManager : BaseManager<AppUser, IAppUserDal>, IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAppUserDal _appUserDal;

    public AppUserManager(IAppUserDal tdal, UserManager<AppUser> userManager, IAppUserDal appUserDal) : base(tdal)
    {
        _userManager = userManager;
        _appUserDal = appUserDal;
    }

    [ValidationAspect(typeof(CreateAppUserValidator), Priority = 1)]
    public async Task<IReturnType> AddAsync(AppUser user, string password)
    {
        try
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
            }
            else
            {
                return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }
    [ValidationAspect(typeof(UpdateAppUserInfoValidator), Priority = 1)]
    public async Task<IReturnType> UpdateAsync(AppUser user)
    {
        try
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Add);

            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }

}

