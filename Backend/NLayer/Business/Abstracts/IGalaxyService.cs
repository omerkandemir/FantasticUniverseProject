using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IGalaxyService : IEntityServiceRepository<
        CreatedGalaxyResponse, CreateGalaxyRequest,
        UpdatedGalaxyResponse, UpdateGalaxyRequest,
        DeletedGalaxyResponse, DeleteGalaxyRequest,
        GetAllGalaxyResponse>
    {
    }
}
