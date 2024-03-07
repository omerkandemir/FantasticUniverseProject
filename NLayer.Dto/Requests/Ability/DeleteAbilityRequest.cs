using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Requests.Ability
{
    public class DeleteAbilityRequest : IDeleteRequest
    {
        public int Id { get; set; }
    }
}
