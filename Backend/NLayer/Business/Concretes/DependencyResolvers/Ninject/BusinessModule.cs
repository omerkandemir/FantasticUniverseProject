using Ninject.Modules;
using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;

namespace NLayer.Business.Concretes.DependencyResolvers.Ninject;

public class BusinessModule : NinjectModule
{
    public override void Load()
    {
        Bind<IAbilityService>().To<AbilityManager>().InSingletonScope();
        Bind<IAbilityDal>().To<EfAbilityDal>().InSingletonScope();

        Bind<IAdventureService>().To<AdventureManager>().InSingletonScope();
        Bind<IAdventureDal>().To<EfAdventureDal>().InSingletonScope();

        Bind<ICharacterService>().To<CharacterManager>().InSingletonScope();
        Bind<ICharacterDal>().To<EfCharacterDal>().InSingletonScope();

        Bind<IGalaxyService>().To<GalaxyManager>().InSingletonScope();
        Bind<IGalaxyDal>().To<EfGalaxyDal>().InSingletonScope();

        Bind<IPlanetService>().To<PlanetManager>().InSingletonScope();
        Bind<IPlanetDal>().To<EfPlanetDal>().InSingletonScope();

        Bind<ISpeciesService>().To<SpeciesManager>().InSingletonScope();
        Bind<ISpeciesDal>().To<EfSpeciesDal>().InSingletonScope();

        Bind<IStarService>().To<StarManager>().InSingletonScope();
        Bind<IStarDal>().To<EfStarDal>().InSingletonScope();

        Bind<ITimeLineService>().To<TimeLineManager>().InSingletonScope();
        Bind<ITimeLineDal>().To<EfTimeLineDal>().InSingletonScope();

        Bind<IUnionCharacterService>().To<UnionCharacterManager>().InSingletonScope();
        Bind<IUnionCharacterDal>().To<EfUnionCharacterDal>().InSingletonScope();

        Bind<IUnionService>().To<UnionManager>().InSingletonScope();
        Bind<IUnionDal>().To<EfUnionDal>().InSingletonScope();

        Bind<IUniverseService>().To<UniverseManager>().InSingletonScope();
        Bind<IUniverseDal>().To<EfUniverseDal>().InSingletonScope();

        Bind<IAdventureCharacterService>().To<AdventureCharacterManager>().InSingletonScope();
        Bind<IAdventureCharacterDal>().To<EfAdventureCharacterDal>().InSingletonScope();
    }
}
