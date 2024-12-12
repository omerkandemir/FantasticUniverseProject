using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AppRole;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppRole;

namespace NLayer.Dto.Managers.Abstract;

public interface IAppRoleDto : IEntityRepositoryAsyncDto<
    IGetAppRoleResponse,
    CreateAppRoleRequest,
    UpdateAppRoleRequest,
    DeleteConfirmationAppRoleRequest,
    GetAppRoleResponse,
    GetAllAppRoleResponse>
{
}
