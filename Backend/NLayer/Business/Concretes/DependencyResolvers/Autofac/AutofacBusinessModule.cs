﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.AutoMapper.Profiles;
using NLayer.Business.Concretes.Managers;
using NLayer.Core.Utilities.Interceptors;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;

namespace NLayer.Business.Concretes.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
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

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();


        builder.Register(context =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assembly);
                cfg.AddProfile<AbilityCharacterProfile>();
                cfg.AddProfile<AbilityProfile>();
                cfg.AddProfile<AdventureCharacterProfile>();
                cfg.AddProfile<AdventureProfile>();
                cfg.AddProfile<CharacterProfile>();
                cfg.AddProfile<GalaxyProfile>();
                cfg.AddProfile<PlanetProfile>();
                cfg.AddProfile<SpeciesProfile>();
                cfg.AddProfile<StarProfile>();
                cfg.AddProfile<TimeLineProfile>();
                cfg.AddProfile<UnionCharacterProfile>();
                cfg.AddProfile<UnionProfile>();
                cfg.AddProfile<UniverseProfile>();
            });
            return config.CreateMapper();
        }).As<IMapper>().SingleInstance();
    }
}



