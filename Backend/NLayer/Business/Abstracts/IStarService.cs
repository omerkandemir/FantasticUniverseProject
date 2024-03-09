using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;

namespace NLayer.Business.Abstracts;

public interface IStarService : IEntityServiceRepository<
    CreatedStarResponse, CreateStarRequest,
    UpdatedStarResponse, UpdateStarRequest,
    DeletedStarResponse, DeleteStarRequest,
    GetAllStarResponse>
{
}
