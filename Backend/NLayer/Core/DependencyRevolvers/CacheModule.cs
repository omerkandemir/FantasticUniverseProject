using NLayer.Core.CrossCuttingConcern.Caching.Redis;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.Utilities.IOC;
using Autofac;
using StackExchange.Redis;

namespace NLayer.Core.DependencyRevolvers;

public class CacheModule : IModule
{
    public void Load(ContainerBuilder builder)
    {

        builder.Register(c =>
        {
            var configurationOptions = ConfigurationOptions.Parse("localhost:6379");
            return ConnectionMultiplexer.Connect(configurationOptions);
        }).As<IConnectionMultiplexer>().SingleInstance();

        builder.RegisterType<RedisCacheManager>().As<ICacheManager>().SingleInstance();
    }
}
