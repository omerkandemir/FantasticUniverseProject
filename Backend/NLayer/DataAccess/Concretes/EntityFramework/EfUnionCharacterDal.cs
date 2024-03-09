using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.Concretes.EntityFramework
{
    public class EfUnionCharacterDal : EfEntityRepositoryBase<UnionCharacter, FantasticUniverseProjectContext>, IUnionCharacterDal
    {
    }
}
