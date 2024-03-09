using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.AdventureCharacter
{
    public class UpdateAdventureCharacterRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public int AdventureId { get; set; }
        public int CharacterId { get; set; }
    }
}
