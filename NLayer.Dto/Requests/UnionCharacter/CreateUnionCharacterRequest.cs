using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.UnionCharacter
{
    public class CreateUnionCharacterRequest : ICreateRequest
    {
        public int UnionId { get; set; }
        public int CharacterId { get; set; }

    }
}
