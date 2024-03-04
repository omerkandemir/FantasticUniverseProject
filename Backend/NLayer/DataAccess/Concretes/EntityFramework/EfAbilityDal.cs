using NLayerDataAccess.Concretes.EntityFramework;
using NLayerDataAccess.Abstracts;
using NLayerEntities.Concretes;
using NLAyerCore.DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDataAccess.Concretes.EntityFramework
{
    public class EfAbilityDal : EfEntityRepositoryBase<Ability, FantasticUniverseProjectContext> , IAbilityDal
    {
     
    }
}
