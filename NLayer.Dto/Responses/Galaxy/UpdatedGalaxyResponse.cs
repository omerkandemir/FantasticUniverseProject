using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Responses.Galaxy
{
    public class UpdatedGalaxyResponse : IUpdatedResponse
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UniverseId { get; set; }
        public string Name { get; set; }
    }
}
