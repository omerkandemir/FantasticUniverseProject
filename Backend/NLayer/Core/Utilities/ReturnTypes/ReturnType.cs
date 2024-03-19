using NLayer.Core.Utilities.Infos;

namespace NLayer.Core.Utilities.ReturnTypes;

public class ReturnType : IReturnType
{
    public ReturnType(string message, CrudOperation crudOperation, Exception exception, bool success = false)
    {
        Message = message;
        CrudOperation = crudOperation;
        Exception = exception;
        Success = success;
    }
    public ReturnType(string message, CrudOperation crudOperation, bool success = true)
    {
        Message = message;
        CrudOperation = crudOperation;
        Success = success;
    }

    public ReturnType(string message, Exception exception, bool success = false)
    {
        Message = message;
        Exception = exception;
        Success = success;
    }

    public ReturnType(string message, bool success = true)
    {
        Message = message;
        Success = success;
    }

    public ReturnType(bool success)
    {
        Success = success;
    }
    public ReturnType(CrudOperation crudOperation)
    {
        CrudOperation = crudOperation;
    }
    public bool Success { get; }
    public string Message { get; }

    public Exception Exception { get; }
    public CrudOperation CrudOperation { get; }
}
