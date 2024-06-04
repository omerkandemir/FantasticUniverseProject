using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.AppUser;

namespace NLayer.Dto.Managers.Abstract;

public interface IAppUserDto : IEntityRepositoryDto<
    CreateAppUserRequest,
    UpdateAppUserRequest,
    DeleteAppUserRequest,
    GetAllAppUserResponse>
{
    Task<IErrorResponse> AddAsync(CreateAppUserRequest request);
}
