using NLayer.Business.Abstracts;
using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.Authorization.Abstract;
using NLayer.Core.Entities.Authorization;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;

namespace NLayer.Business.Concretes.Managers;

public class AppRoleManager : BaseManagerAsync<AppRole, IAppRoleDal, int>, IAppRoleService
{
    IRoleService<AppRole> _roleService;
    public AppRoleManager(IAppRoleDal tdal, IRoleService<AppRole> roleService) : base(tdal)
    {
        _roleService = roleService;
    }
    [CacheRemoveAspect("GetAllAsync")]
    public override async Task<IReturnType> AddAsync(AppRole value)
    {
        try
        {
            var result = await _roleService.CreateRoleAsync(value);

            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
            }
            else
            {
                return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, false);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }
    [CacheRemoveAspect("GetAllAsync")]
    public override async Task<IReturnType> UpdateAsync(AppRole value)
    {
        try
        {
            var existingRole = await _roleService.FindRoleById(value.Id);
            existingRole.Name = value.Name;
            existingRole.NormalizedName = value.Name.ToUpper();
            existingRole.ConcurrencyStamp = value.ConcurrencyStamp;
            var result = await _roleService.UpdateRoleAsync(existingRole);

            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, false);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }
    [CacheRemoveAspect("GetAllAsync")]
    public override async Task<IReturnType> DeleteAsync(AppRole value)
    {
        var existingRole = await _roleService.FindRoleById(value.Id);
        var result = await _roleService.DeleteRoleAsync(existingRole);
        if (result.Succeeded)
        {
            return new ReturnType(GetDatasInfo.Deleted, CrudOperation.Delete);
        }
        else
        {
            return new ReturnType(GetDatasInfo.DeletedFailed, CrudOperation.Delete, false);
        }
    }
}
