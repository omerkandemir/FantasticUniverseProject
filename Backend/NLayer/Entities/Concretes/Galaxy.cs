using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Galaxy : BaseEntity<int>
    {
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
        public string Name { get; set; }
        public ICollection<Star> Stars { get; set; }
    }
}
