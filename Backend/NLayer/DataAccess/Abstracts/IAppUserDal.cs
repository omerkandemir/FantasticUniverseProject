using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Authentication;

namespace NLayer.DataAccess.Abstracts;

public interface IAppUserDal : IEntityRepository<AppUser>
{
    Task<AppUser> GetByIdAsync(int id);
    Task<bool> UpdateAsync(AppUser user);
}
