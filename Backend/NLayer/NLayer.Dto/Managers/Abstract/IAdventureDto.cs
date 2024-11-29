using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;

namespace NLayer.Dto.Managers.Abstract;

public interface IAdventureDto : IEntityRepositoryAsyncDto<
    IGetAdventureResponse,
    CreateAdventureRequest,
    UpdateAdventureRequest,
    DeleteAdventureRequest,
    GetAdventureResponse,
    GetAllAdventureResponse>
{
}
