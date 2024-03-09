using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IUnionService : IEntityServiceRepository<
        CreatedUnionResponse, CreateUnionRequest,
        UpdatedUnionResponse, UpdateUnionRequest,
        DeletedUnionResponse, DeleteUnionRequest,
        GetAllUnionResponse>
    {
    }
}
