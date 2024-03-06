using NLayer.Core.DataAccess.Abstracts;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.Abstracts
{
    public interface ICharacterDal : IEntityRepository<Character>
    {
    }
}
