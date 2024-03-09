using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IStarService : IEntityServiceRepository<
        CreatedStarResponse, CreateStarRequest,
        UpdatedStarResponse, UpdateStarRequest,
        DeletedStarResponse, DeleteStarRequest,
        GetAllStarResponse>
    {
    }
}
