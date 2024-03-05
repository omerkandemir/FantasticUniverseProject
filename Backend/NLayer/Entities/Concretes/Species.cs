using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Species : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
