using Microsoft.Extensions.DependencyInjection;
using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;

namespace NLayer.Business.Concretes.DependencyResolvers.ServiceCollections;

public static class ServiceCollectionExtensions
{
    public static void MyCollections(this IServiceCollection services)
    {
        services.AddSingleton<IAbilityService, AbilityManager>();
        services.AddSingleton<IAbilityDal, EfAbilityDal>();

        services.AddSingleton<IAbilityCharacterService, AbilityCharacterManager>();
        services.AddSingleton<IAbilityCharacterDal, EfAbilityCharacterDal>();

        services.AddSingleton<IAdventureService, AdventureManager>();
        services.AddSingleton<IAdventureDal, EfAdventureDal>();

        services.AddSingleton<ICharacterService, CharacterManager>();
        services.AddSingleton<ICharacterDal, EfCharacterDal>();

        services.AddSingleton<IGalaxyService, GalaxyManager>();
        services.AddSingleton<IGalaxyDal, EfGalaxyDal>();

        services.AddSingleton<IPlanetService, PlanetManager>();
        services.AddSingleton<IPlanetDal, EfPlanetDal>();

        services.AddSingleton<ISpeciesService, SpeciesManager>();
        services.AddSingleton<ISpeciesDal, EfSpeciesDal>();

        services.AddSingleton<IStarService, StarManager>();
        services.AddSingleton<IStarDal, EfStarDal>();

        services.AddSingleton<ITimeLineService, TimeLineManager>();
        services.AddSingleton<ITimeLineDal, EfTimeLineDal>();

        services.AddSingleton<IUnionCharacterService, UnionCharacterManager>();
        services.AddSingleton<IUnionCharacterDal, EfUnionCharacterDal>();

        services.AddSingleton<IUnionService, UnionManager>();
        services.AddSingleton<IUnionDal, EfUnionDal>();

        services.AddSingleton<IUniverseService, UniverseManager>();
        services.AddSingleton<IUniverseDal, EfUniverseDal>();

        services.AddSingleton<IAdventureCharacterService, AdventureCharacterManager>();
        services.AddSingleton<IAdventureCharacterDal, EfAdventureCharacterDal>();
    }
}


