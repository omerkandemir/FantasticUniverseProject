using NLayer.Core.Utilities.Infos;

namespace NLayer.Core.Utilities.ReturnTypes;

public interface IReturnType
{
    bool Success { get; }
    string Message { get; }
    Exception  Exception { get; }
    CrudOperation CrudOperation { get; }
}
