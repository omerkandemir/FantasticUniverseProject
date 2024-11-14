using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Universe;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseDto : IEntityRepositoryAsyncDto<
    CreateUniverseRequest,
    UpdateUniverseRequest,
    DeleteUniverseRequest,
    GetAllUniverseResponse>
{
    Task<IResponse> CreateUniverseAsync(CreateUniverseRequest request);
    Task<IGetResponse> GetUniverseDetailAsync(int id);
    Task<ICollection<GetAllUniverseResponse>> GetUserUniversesAsync(int userId);
}
