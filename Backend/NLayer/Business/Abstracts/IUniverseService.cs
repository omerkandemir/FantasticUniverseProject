using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IUniverseService : IEntityServiceRepository<
        CreatedUniverseResponse, CreateUniverseRequest,
        UpdatedUniverseResponse, UpdateUniverseRequest,
        DeletedUniverseResponse, DeleteUniverseRequest,
        GetAllUniverseResponse>
    {
    }
}
