using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Responses.Planet
{
    public class GetAllPlanetResponse : IGetAllResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StarId { get; set; }
        public string Name { get; set; }
        public int PlanetAge { get; set; }
        public int PlanetTemperature { get; set; }
        public int PlanetMass { get; set; }

    }
}
