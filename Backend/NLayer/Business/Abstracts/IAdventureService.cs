using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IAdventureService : IEntityServiceRepository<
        CreatedAdventureResponse, CreateAdventureRequest,
        UpdatedAdventureResponse, UpdateAdventureRequest,
        DeletedAdventureResponse, DeleteAdventureRequest,
        GetAllAdventureResponse>
    {
    }
}
