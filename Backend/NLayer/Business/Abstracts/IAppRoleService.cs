using NLayer.Core.Business.Abstract;
using NLayer.Core.Entities.Authorization;

namespace NLayer.Business.Abstracts;

public interface IAppRoleService : IEntityServiceRepositoryAsync<AppRole, int> 
{
}
