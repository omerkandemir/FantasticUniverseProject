using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Dto.ReturnTypes;

public static class ResponseFactory
{
    public static ISuccessResponse<T> CreateSuccessResponse<T>(object data, T entity) where T : class, IEntity, new()
    {
        return new SuccessResponse<T>(data, entity);
    }

    public static IErrorResponse CreateErrorResponse(IReturnType result)
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
        return new ErrorResponse(errorMessage);
    }
    public static ISuccessResponse<T> CreateSuccessListResponse<T>(object data, T entity) where T: class, IEntity, new()
    {
        return new SuccessListResponse<T>(data, entity);
    }
    public static IErrorResponse CreateErrorListResponse(IReturnType result)
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
        return new ErrorListResponse(errorMessage);
    }
}
