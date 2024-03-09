using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IUnionCharacterService : IEntityServiceRepository<
        CreatedUnionCharacterResponse, CreateUnionCharacterRequest,
        UpdatedUnionCharacterResponse, UpdateUnionCharacterRequest,
        DeletedUnionCharacterResponse, DeleteUnionCharacterRequest,
        GetAllUnionCharacterResponse>
    {
    }
}
