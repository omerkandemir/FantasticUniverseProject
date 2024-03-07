using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Character
{
    public class CreateCharacterRequest : ICreateRequest
    {
        public int? AbilityId { get; set; }
        public int? SpeciesId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int UnionId { get; set; }
        public int? MasterCharacterId { get; set; }
        public int? ApprenticeId { get; set; }
    }
}
