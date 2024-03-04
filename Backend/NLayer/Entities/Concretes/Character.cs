using NLayerCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerEntities.Concretes
{
    public class Character : BaseEntity<int>
    {
        public int? AbilityId { get; set; }
        public Ability Ability { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int UnionId { get; set; }
        public int? MasterCharacterId { get; set; }
        public int? ApprenticeId { get; set; }
    }
}
