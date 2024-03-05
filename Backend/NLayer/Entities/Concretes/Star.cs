using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Star : BaseEntity<int>
    {
        public int GalaxyId { get; set; }
        public Galaxy Galaxy { get; set; }
        public string Name { get; set; }
        public ICollection<Planet> Planets { get; set; }
    }
}
