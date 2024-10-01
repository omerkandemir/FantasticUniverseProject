using Microsoft.AspNetCore.Http;
using NLayer.Core.Utilities.IOC;
using System.Diagnostics;
using Autofac;
using NLayer.Core.Utilities.ImageOperations;

namespace NLayer.Core.DependencyRevolvers;

public class CoreModule : IModule
{
    public void Load(ContainerBuilder builder)
    {
        // Middleware'in bağımlılığı olan IHttpContextAccessor kaydı
        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

        builder.RegisterType<GetDefaultImages>().As<IGetDefaultImages>().SingleInstance();
        builder.RegisterType<Stopwatch>().SingleInstance();
    }
}
