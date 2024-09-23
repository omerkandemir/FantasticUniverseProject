using Newtonsoft.Json;
using NLayer.Core.Utilities.Infos;

namespace NLayer.Core.Utilities.ReturnTypes;

public class DataReturnType<T> : ReturnType, IDataReturnType<T>
{
    [JsonConstructor]
    public DataReturnType(T data, string message, CrudOperation crudOperation) : base(message, crudOperation, true)
    {
        Data = data;
    }
    public DataReturnType(string message, CrudOperation crudOperation, Exception exception) : base(message, crudOperation, exception, false)
    {
    }
    public T Data { get; } 
}
