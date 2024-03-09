using NLayer.Core.Business.Abstract;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Abstracts
{
    public interface IAdventureCharacterService : IEntityServiceRepository<
        CreatedAdventureCharacterResponse, CreateAdventureCharacterRequest,
        UpdatedAdventureCharacterResponse, UpdateAdventureCharacterRequest,
        DeletedAdventureCharacterResponse, DeleteAdventureCharacterRequest,
        GetAllAdventureCharacterResponse>
    {
    }
}
