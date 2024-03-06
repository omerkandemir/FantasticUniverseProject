using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Character : BaseEntity<int>
    {
        public int? AbilityId { get; set; }
        public Ability Ability { get; set; }
        public int? SpeciesId { get; set; }
        public Species Species { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int UnionId { get; set; }
        public Union Union { get; set; }
        public int? MasterCharacterId { get; set; }
        public int? ApprenticeId { get; set; }
        public ICollection<Adventure> Adventures { get; set; }
        public ICollection<Union> Unions { get; set; }
    }
}
