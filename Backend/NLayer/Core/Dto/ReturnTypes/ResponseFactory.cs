using NLayer.Core.Utilities.ReturnTypes;

namespace NLayer.Core.Dto.ReturnTypes;

public static class ResponseFactory
{
    public static IErrorResponse CreateSuccessResponse(object data)
    {
        return new SuccessResponse(data);
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
}
