using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Dto.ReturnTypes;

public static class ResponseFactory
{
    public static ISuccessResponse CreateSuccessResponse(object data, string message = "İşlem başarılı.")
    {
        return new SuccessResponse(data, message);
    }
    public static ISuccessResponse<T> CreateSuccessResponse<T>(T entity, object data, string message = "İşlem başarılı.") where T : class, IEntity, new()
    {
        return new SuccessResponse<T>(entity, data, message);
    }
    public static ISuccessListResponse<T> CreateSuccessListResponse<T>(ICollection<T> entities, object data, string message = "Liste başarıyla döndürüldü.") where T : IGetResponse
    {
        return new SuccessListResponse<T>(entities, data, message);
    }
    public static IErrorResponse CreateErrorResponse(Exception exceptionMessage, object additionalData = null, string message = "Bir hata oluştu.")
    {
        var errors = new List<string>();
        errors.Add(exceptionMessage.Message);
        var errorMessage = string.Join(", ", errors);
        return new ErrorResponse(errorMessage, additionalData, message);
    }
    public static IErrorResponse CreateErrorResponse(IReturnType result, string message = "Bir hata oluştu.")
    {
        var errors = new List<string>();

        if (result.Exception != null)
        {
            errors.Add(result.Exception.Message);
        }
        else if (!string.IsNullOrEmpty(result.Message))
        {
            errors.Add(result.Message);
        }

        var errorMessage = string.Join(", ", errors);
        return new ErrorResponse(errorMessage, null, message);
    }
    public static IErrorResponse CreateErrorResponse(string message = "Bir hata oluştu.")
    {
        return new ErrorResponse(message);
    }
}
