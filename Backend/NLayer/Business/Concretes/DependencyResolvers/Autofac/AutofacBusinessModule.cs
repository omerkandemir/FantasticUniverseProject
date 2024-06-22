using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Create;
using NLayer.Business.Concretes.Managers;
using NLayer.Core.Utilities.ImageOperations;
using NLayer.Core.Utilities.Interceptors;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Mapper.Requests.AbilityCharacter;

namespace NLayer.Business.Concretes.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterServices(builder);
        ConfigureContainer(builder);
    }

    private void ConfigureContainer(ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        var config = new MapperConfiguration(cfg =>
        {
            // Tüm derlemeleri yükle
            var assemblies = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies();

            // Her bir derlemeyi yükle ve içindeki tüm türleri tarayarak AutoMapper profillerini bul
            foreach (var assemblyName in assemblies)
            {
                var assembly = System.Reflection.Assembly.Load(assemblyName);
                cfg.AddMaps(assembly);
            }
        });
        builder.RegisterInstance(config.CreateMapper())
            .As<IMapper>()
            .SingleInstance();
    }

    private void RegisterServices(ContainerBuilder builder)
    {
        builder.RegisterType<AbilityManager>().As<IAbilityService>().SingleInstance();
        builder.RegisterType<EfAbilityDal>().As<IAbilityDal>().SingleInstance();

        builder.RegisterType<AbilityCharacterManager>().As<IAbilityCharacterService>().SingleInstance();
        builder.RegisterType<EfAbilityCharacterDal>().As<IAbilityCharacterDal>().SingleInstance();

        builder.RegisterType<AdventureManager>().As<IAdventureService>().SingleInstance();
        builder.RegisterType<EfAdventureDal>().As<IAdventureDal>().SingleInstance();

        builder.RegisterType<CharacterManager>().As<ICharacterService>().SingleInstance();
        builder.RegisterType<EfCharacterDal>().As<ICharacterDal>().SingleInstance();

        builder.RegisterType<GalaxyManager>().As<IGalaxyService>().SingleInstance();
        builder.RegisterType<EfGalaxyDal>().As<IGalaxyDal>().SingleInstance();

        builder.RegisterType<PlanetManager>().As<IPlanetService>().SingleInstance();
        builder.RegisterType<EfPlanetDal>().As<IPlanetDal>().SingleInstance();

        builder.RegisterType<SpeciesManager>().As<ISpeciesService>().SingleInstance();
        builder.RegisterType<EfSpeciesDal>().As<ISpeciesDal>().SingleInstance();

        builder.RegisterType<StarManager>().As<IStarService>().SingleInstance();
        builder.RegisterType<EfStarDal>().As<IStarDal>().SingleInstance();

        builder.RegisterType<TimeLineManager>().As<ITimeLineService>().SingleInstance();
        builder.RegisterType<EfTimeLineDal>().As<ITimeLineDal>().SingleInstance();

        builder.RegisterType<UnionCharacterManager>().As<IUnionCharacterService>().SingleInstance();
        builder.RegisterType<EfUnionCharacterDal>().As<IUnionCharacterDal>().SingleInstance();

        builder.RegisterType<UnionManager>().As<IUnionService>().SingleInstance();
        builder.RegisterType<EfUnionDal>().As<IUnionDal>().SingleInstance();

        builder.RegisterType<UniverseManager>().As<IUniverseService>().SingleInstance();
        builder.RegisterType<EfUniverseDal>().As<IUniverseDal>().SingleInstance();

        builder.RegisterType<AdventureCharacterManager>().As<IAdventureCharacterService>().SingleInstance();
        builder.RegisterType<EfAdventureCharacterDal>().As<IAdventureCharacterDal>().SingleInstance();

        builder.RegisterType<UniverseImageManager>().As<IUniverseImageService>().SingleInstance();
        builder.RegisterType<EfUniverseImageDal>().As<IUniverseImageDal>().SingleInstance();

        builder.RegisterType<UserImageManager>().As<IUserImageService>().SingleInstance();
        builder.RegisterType<EfUserImageDal>().As<IUserImageDal>().SingleInstance();

        builder.RegisterType<GetDefaultImages>().As<IGetDefaultImages>().SingleInstance();

        builder.RegisterType<CreateAbilityCharacterValidator>().As<IValidator<CreateAbilityCharacterRequest>>();
    }
}



