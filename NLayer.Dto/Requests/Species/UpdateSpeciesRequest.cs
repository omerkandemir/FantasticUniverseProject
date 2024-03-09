using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Species
{
    public class UpdateSpeciesRequest : IUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
