using Autofac;
using NLayer.Core.Utilities.IOC;
using NLayer.Core.CrossCuttingConcern.Logging.Loggers;
using NLayer.Core.CrossCuttingConcern.Logging;

namespace NLayer.Core.DependencyRevolvers;
public class LogModule : IModule
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<FileLogger>().As<ILoggerService>().SingleInstance();
        builder.RegisterType<DatabaseLogger>().As<ILoggerService>().SingleInstance();
        builder.RegisterType<RedisLogger>().As<ILoggerService>().SingleInstance();
        builder.RegisterType<ElasticSearchLogger>().As<ILoggerService>().SingleInstance();
    }
}
