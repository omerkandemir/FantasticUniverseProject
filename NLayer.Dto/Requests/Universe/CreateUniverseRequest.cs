using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Universe
{
    public class CreateUniverseRequest : ICreateRequest
    {
        public string Name { get; set; }
        public int TimeLineId { get; set; }
    }
}
