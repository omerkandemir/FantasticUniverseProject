using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.UnionCharacter
{
    public class UpdateUnionCharacterRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public int UnionId { get; set; }
        public int CharacterId { get; set; }

    }
}
