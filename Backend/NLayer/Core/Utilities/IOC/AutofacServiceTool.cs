using Autofac;

namespace NLayer.Core.Utilities.IOC;

public static class AutofacServiceTool
{
    public static IContainer Container { get; private set; }

    // Container'ın set edilmesi
    public static void SetContainer(IContainer container)
    {
        Container = container;
    }

    // Generic bir servis çözümleme metodu
    public static T Resolve<T>()
    {
        return Container.Resolve<T>();
    }
}
