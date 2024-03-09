using Ninject;
using NLayer.Business.Concretes.DependencyResolvers.Ninject;

namespace NLayer.Business.DependencyResolvers.Ninject;

public class InstanceFactory
{
    public static T GetInstance<T>()
    {
        var kernel = new StandardKernel(new BusinessModule());
        return kernel.Get<T>();
    }
}
