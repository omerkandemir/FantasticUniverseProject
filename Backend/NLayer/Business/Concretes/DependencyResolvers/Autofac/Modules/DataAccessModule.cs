using Autofac;
using NLayer.Core.Utilities.IOC;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;

namespace NLayer.Business.Concretes.DependencyResolvers.Autofac.Modules;

public class DataAccessModule : IModule
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EfAbilityDal>().As<IAbilityDal>().SingleInstance();
        builder.RegisterType<EfAbilityCharacterDal>().As<IAbilityCharacterDal>().SingleInstance();
        builder.RegisterType<EfAdventureDal>().As<IAdventureDal>().SingleInstance();
        builder.RegisterType<EfAdventureCharacterDal>().As<IAdventureCharacterDal>().SingleInstance();
        builder.RegisterType<EfCharacterDal>().As<ICharacterDal>().SingleInstance();
        builder.RegisterType<EfGalaxyDal>().As<IGalaxyDal>().SingleInstance();
        builder.RegisterType<EfPlanetDal>().As<IPlanetDal>().SingleInstance();
        builder.RegisterType<EfSpeciesDal>().As<ISpeciesDal>().SingleInstance();
        builder.RegisterType<EfStarDal>().As<IStarDal>().SingleInstance();
        builder.RegisterType<EfTimeLineDal>().As<ITimeLineDal>().SingleInstance();
        builder.RegisterType<EfUnionDal>().As<IUnionDal>().SingleInstance();
        builder.RegisterType<EfUnionCharacterDal>().As<IUnionCharacterDal>().SingleInstance();
        builder.RegisterType<EfUniverseDal>().As<IUniverseDal>().SingleInstance();
        builder.RegisterType<EfUniverseImageDal>().As<IUniverseImageDal>().SingleInstance();
        builder.RegisterType<EfUserImageDal>().As<IUserImageDal>().SingleInstance();
        builder.RegisterType<EfAppUserDal>().As<IAppUserDal>().SingleInstance();
    }
}
