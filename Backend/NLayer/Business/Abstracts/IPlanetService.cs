using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IPlanetService : IEntityServiceRepository<
        CreatedPlanetResponse, CreatePlanetRequest,
        UpdatedPlanetResponse, UpdatePlanetRequest,
        DeletedPlanetResponse, DeletePlanetRequest,
        GetAllPlanetResponse>
    {
    }
}
