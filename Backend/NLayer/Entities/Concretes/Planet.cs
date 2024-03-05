using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Planet : BaseEntity<int>
    {
        public int StarId { get; set; }
        public Star Star { get; set; }
        public string Name { get; set; }
        public int PlanetAge { get; set; }
        public int PlanetTemperature { get; set; }
        public int PlanetMass { get; set; }
        public ICollection<Adventure> Adventures { get; set; }
    }
}
