using NLayer.Core.Dto.Abstracts;

namespace NLayer.Core.Dto.ReturnTypes;

public class ErrorResponse : IErrorResponse
{
    public bool Success => false;
    public string ErrorMessage { get; }
    public string Message { get; }
    public object AdditionalData { get; }
    public ErrorResponse(string errorMessage, object additionalData = null, string message = "Bir hata oluştu.")
    {
        ErrorMessage = errorMessage;
        AdditionalData = additionalData;
        Message = message;
    }
    public ErrorResponse(string message = "Bir hata oluştu")
    {
        Message = message;
    }
}
