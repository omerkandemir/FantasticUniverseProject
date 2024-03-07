using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Planet
{
    public class UpdatePlanetRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int StarId { get; set; }
        public string Name { get; set; }
        public int PlanetAge { get; set; }
        public int PlanetTemperature { get; set; }
        public int PlanetMass { get; set; }
    }
}
