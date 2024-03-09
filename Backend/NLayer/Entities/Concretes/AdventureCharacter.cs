using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class AdventureCharacter : BaseEntity<int>
    {
        public int AdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
