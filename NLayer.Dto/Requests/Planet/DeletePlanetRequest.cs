using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Planet
{
    public class DeletePlanetRequest : IDeleteRequest
    {
        public int Id { get; set; }
    }
}
