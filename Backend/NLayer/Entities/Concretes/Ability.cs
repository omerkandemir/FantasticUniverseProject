using NLayerCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerEntities.Concretes
{
    public class Ability : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
