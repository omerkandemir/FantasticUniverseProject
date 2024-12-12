using Autofac;
using NLayer.Business.Concretes.DependencyResolvers.Autofac;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Managers.Concrete;

namespace NLayer.Dto.Autofac;

public class AutofacDtoMudule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AbilityDto>().As<IAbilityDto>().SingleInstance();
        builder.RegisterType<AbilityCharacterDto>().As<IAbilityCharacterDto>().SingleInstance();
        builder.RegisterType<AdventureCharacterDto>().As<IAdventureCharacterDto>().SingleInstance();
        builder.RegisterType<AdventureDto>().As<IAdventureDto>().SingleInstance();
        builder.RegisterType<CharacterDto>().As<ICharacterDto>().SingleInstance();
        builder.RegisterType<GalaxyDto>().As<IGalaxyDto>().SingleInstance();
        builder.RegisterType<PlanetDto>().As<IPlanetDto>().SingleInstance();
        builder.RegisterType<SpeciesDto>().As<ISpeciesDto>().SingleInstance();
        builder.RegisterType<StarDto>().As<IStarDto>().SingleInstance();
        builder.RegisterType<TimeLineDto>().As<ITimeLineDto>().SingleInstance();
        builder.RegisterType<UnionCharacterDto>().As<IUnionCharacterDto>().SingleInstance();
        builder.RegisterType<UnionDto>().As<IUnionDto>().SingleInstance();
        builder.RegisterType<UniverseDto>().As<IUniverseDto>().SingleInstance();
        builder.RegisterType<UniverseImageDto>().As<IUniverseImageDto>().SingleInstance();
        builder.RegisterType<UserImageDto>().As<IUserImageDto>().SingleInstance();
        builder.RegisterType<AppUserDto>().As<IAppUserDto>().SingleInstance();
        builder.RegisterType<AppRoleDto>().As<IAppRoleDto>().SingleInstance();
        builder.RegisterModule<AutofacBusinessModule>(); // AutofacModule'ü yükle
    }
}
