using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;
using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.Concretes.EntityFramework
{
    public class EfAbilityDal : EfEntityRepositoryBase<Ability, FantasticUniverseProjectContext> , IAbilityDal
    {
     
    }
}
