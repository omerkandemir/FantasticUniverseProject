using Ninject.Modules;
using NLayerBusiness.Abstracts;
using NLayerDataAccess.Abstracts;
using NLayerDataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBusiness.Concretes.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAbilityService>().To<AbilityManager>().InSingletonScope();
            Bind<IAbilityDal>().To<EfAbilityDal>().InSingletonScope();
        }
    }
}
