using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;

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
