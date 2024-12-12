using Autofac;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.Managers;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.IOC;

namespace NLayer.Business.Concretes.DependencyResolvers.Autofac.Modules;

public class BusinessModule : IModule
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AbilityManager>().As<IAbilityService>().SingleInstance();
        builder.RegisterType<AbilityCharacterManager>().As<IAbilityCharacterService>().SingleInstance();
        builder.RegisterType<AdventureManager>().As<IAdventureService>().SingleInstance();
        builder.RegisterType<AdventureCharacterManager>().As<IAdventureCharacterService>().SingleInstance();
        builder.RegisterType<CharacterManager>().As<ICharacterService>().SingleInstance();
        builder.RegisterType<GalaxyManager>().As<IGalaxyService>().SingleInstance();
        builder.RegisterType<PlanetManager>().As<IPlanetService>().SingleInstance();
        builder.RegisterType<SpeciesManager>().As<ISpeciesService>().SingleInstance();
        builder.RegisterType<StarManager>().As<IStarService>().SingleInstance();
        builder.RegisterType<TimeLineManager>().As<ITimeLineService>().SingleInstance();
        builder.RegisterType<UnionManager>().As<IUnionService>().SingleInstance();
        builder.RegisterType<UnionCharacterManager>().As<IUnionCharacterService>().SingleInstance();
        builder.RegisterType<UniverseManager>().As<IUniverseService>().SingleInstance();
        builder.RegisterType<UniverseImageManager>().As<IUniverseImageService>().SingleInstance();
        builder.RegisterType<UserImageManager>().As<IUserImageService>().SingleInstance();
        builder.RegisterType<AppRoleManager>().As<IAppRoleService>().SingleInstance();
        builder.RegisterType<AppUserManager>().As<IAppUserService<AppUser,int>>().SingleInstance();
    }
}
