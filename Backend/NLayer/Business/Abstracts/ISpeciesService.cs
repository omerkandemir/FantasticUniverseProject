using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface ISpeciesService : IEntityServiceRepository<
        CreatedSpeciesResponse, CreateSpeciesRequest,
        UpdatedSpeciesResponse, UpdateSpeciesRequest,
        DeletedSpeciesResponse, DeleteSpeciesRequest,
        GetAllSpeciesResponse>
    {
    }
}
