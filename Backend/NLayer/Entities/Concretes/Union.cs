using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Union : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public int? UnionLeaderId { get; set; }
        public Character Character { get; set; }
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
