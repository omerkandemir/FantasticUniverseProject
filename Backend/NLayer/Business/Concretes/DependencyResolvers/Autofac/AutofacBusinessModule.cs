using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.DependencyRevolvers;
using NLayer.Core.Utilities.IOC;
using NLayer.Business.Concretes.DependencyResolvers.Autofac.Modules;

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
        SetAutofacContainer(builder);

        var modules = new IModule[]
        {
            new CoreModule(),
            new CacheModule(),
            new DataAccessModule(),
            new BusinessModule(),
        };

        foreach (var module in modules)
        {
            module.Load(builder);
        }
    }

    private static void SetAutofacContainer(ContainerBuilder builder)
    {
        builder.RegisterBuildCallback(container =>
        {
            AutofacServiceTool.SetContainer((IContainer)container);
        });
    }
}



