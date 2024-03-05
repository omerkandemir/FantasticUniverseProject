using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Universe : BaseEntity<int>
    {
        public string Name { get; set; }
        public int TimeLineId { get; set; }
        //Bunu yeniden tasarla
        public TimeLine TimeLine { get; set; }
        public ICollection<Galaxy> Galaxies { get; set; }
        public ICollection<Union> Unions { get; set; }
    }
}
