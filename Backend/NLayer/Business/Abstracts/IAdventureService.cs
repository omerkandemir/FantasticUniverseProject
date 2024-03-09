using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;

namespace NLayer.Business.Abstracts;

public interface IAdventureService : IEntityServiceRepository<
    CreatedAdventureResponse, CreateAdventureRequest,
    UpdatedAdventureResponse, UpdateAdventureRequest,
    DeletedAdventureResponse, DeleteAdventureRequest,
    GetAllAdventureResponse>
{
}
