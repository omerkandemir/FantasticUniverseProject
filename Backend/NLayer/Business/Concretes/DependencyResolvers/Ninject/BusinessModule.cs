using Ninject.Modules;
using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes.DependencyResolvers.Ninject
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
