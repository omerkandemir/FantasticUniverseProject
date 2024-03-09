using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface ICharacterService : IEntityServiceRepository<
        CreatedCharacterResponse, CreateCharacterRequest,
        UpdatedCharacterResponse, UpdateCharacterRequest,
        DeletedCharacterResponse, DeleteCharacterRequest,
        GetAllCharacterResponse>
    {
    }
}
