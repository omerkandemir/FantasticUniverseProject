using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Adventure;

namespace NLayer.Dto.Managers.Abstract
{
    public interface IAdventureDto : IEntityRepositoryDto<
        CreateAdventureRequest,
        UpdateAdventureRequest,
        DeleteAdventureRequest,
        GetAllAdventureResponse>
    {
    }
}
