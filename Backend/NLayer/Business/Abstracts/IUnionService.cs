using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;

namespace NLayer.Business.Abstracts;

public interface IUnionService : IEntityServiceRepository<
    CreatedUnionResponse, CreateUnionRequest,
    UpdatedUnionResponse, UpdateUnionRequest,
    DeletedUnionResponse, DeleteUnionRequest,
    GetAllUnionResponse>
{
}
