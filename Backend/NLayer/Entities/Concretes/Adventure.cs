using NLayer.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entities.Concretes
{
    public class Adventure : BaseEntity<int>
    {
        //Bir olayda birden fazla karakter olacak bu kısmı ileride tasarla
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
        public string AdventureName { get; set; }
        public string Occurrence { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<TimeLine> TimeLines { get; set; }
    }
}
