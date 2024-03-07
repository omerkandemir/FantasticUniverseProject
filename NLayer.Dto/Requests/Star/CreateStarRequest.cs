using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Star
{
    public class CreateStarRequest : ICreateRequest
    {
        public int GalaxyId { get; set; }
        public string Name { get; set; }
    }
}
