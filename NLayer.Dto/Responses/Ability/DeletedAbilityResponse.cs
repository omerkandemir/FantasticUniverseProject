using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Responses.Ability
{
    public class DeletedAbilityResponse : IDeletedResponse
    {
        public int Id { get; set; }
    }
}
