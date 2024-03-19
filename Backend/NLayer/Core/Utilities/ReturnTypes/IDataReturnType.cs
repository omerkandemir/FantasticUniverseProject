namespace NLayer.Core.Utilities.ReturnTypes;

public interface IDataReturnType<out T> : IReturnType
{
    T Data { get; }
}

