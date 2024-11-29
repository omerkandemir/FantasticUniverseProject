using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Universe;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseDto : IEntityRepositoryAsyncDto<
    IGetUniverseResponse,
    CreateUniverseRequest,
    UpdateUniverseRequest,
    DeleteUniverseRequest,
    GetUniverseResponse,
    GetAllUniverseResponse>
{
    Task<IResponse> CreateUniverseAsync(CreateUniverseRequest request);
    Task<IGetResponse> GetUniverseDetailAsync(int id);
    Task<IGetAllResponse<IGetUniverseResponse>> GetUserUniversesAsync(int userId);
}
