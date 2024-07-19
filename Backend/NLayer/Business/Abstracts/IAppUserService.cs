using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Business.Abstracts;

public interface IAppUserService : IEntityServiceRepository<AppUser>
{
    Task<IReturnType> AddAsync(AppUser user, string password);
    Task<IReturnType> UpdateAsync(AppUser user);
}
