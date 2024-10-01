using Autofac;

namespace NLayer.Core.Utilities.IOC;

public interface IModule
{
    void Load(ContainerBuilder builder);
}
