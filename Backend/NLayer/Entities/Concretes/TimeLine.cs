using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class TimeLine : BaseEntity<int>
    {
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
        public int StartingAdventureId { get; set; }
        public Adventure Adventure { get; set; }
        public ICollection<Universe> Universes { get; set; }
    }
}
