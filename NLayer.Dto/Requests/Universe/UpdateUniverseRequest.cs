using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Universe
{
    public class UpdateUniverseRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public int TimeLineId { get; set; }
    }
}
